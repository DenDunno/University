Param(
	[Parameter(Mandatory = $True)]
	[string[]]$IpAddresses,
	[string]$LocalIp,
	[string]$SolutionPath = ".."
)

$ErrorActionPreference = "Stop"
$VerbosePreference = "Continue"

#Set-ExecutionPolicy Unrestricted

Import-Module -Name ".\Invoke-MsBuild.psm1"
Import-Module -Name ".\ParcsSetup.psm1"

& nuget restore "$SolutionPath\Parcs.sln"

Invoke-MsBuild -Path "$SolutionPath\Parcs.sln" -MsBuildParameters "/p:Configuration=Release" -ShowBuildOutputInNewWindow

Start-Daemon -BinFolder "$SolutionPath\Daemon\bin\Release" -LocalIp $LocalIp -Verbose

Start-HostServer -BinFolder "$SolutionPath\HostServer\bin\Release" -LocalIp $LocalIp -IpAddresses $IpAddresses -Verbose
