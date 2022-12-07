$ErrorActionPreference="Stop"

Write-Host "Starting Host Server"

docker run -d --name=hostserver --rm andriikhavro/parcshostserver:windowsservercore-1709

$HostServerIp = (docker inspect -f '{{.NetworkSettings.Networks.nat.IPAddress}}' hostserver) | Out-String

if ($HostServerIp -eq $null)
{
	Write-Error "Host Server hasn't started successfully. Last exit code: $LastExitCode"
	return
}

$HostServerIp = $HostServerIp.Trim()

Write-Host "Starting Daemon. Using Host Server IP: $HostServerIp"

docker run -d --name=daemon1 --rm -e PARCS_HOST_SERVER_IP_ADDRESS=$HostServerIp andriikhavro/parcsdaemon:windowsservercore-1709

docker ps
