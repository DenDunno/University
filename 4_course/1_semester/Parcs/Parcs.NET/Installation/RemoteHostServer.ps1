Install-WindowsFeature -Name Web-Server -IncludeManagementTools
Install-WindowsFeature -Name Web-Asp-Net
Install-WindowsFeature -Name Web-Asp-Net45
New-NetFirewallRule -DisplayName "Parcs HostServer" -Direction Inbound –LocalPort 1234 -Protocol TCP -Action Allow