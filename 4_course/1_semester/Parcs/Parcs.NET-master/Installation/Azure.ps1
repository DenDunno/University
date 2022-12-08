Function Create-VMConfig
{
	Param
	(
		$VMName,
		$Cred,
		$Nic
	)
	
	New-AzureRmVMConfig -VMName $VMName -VMSize Standard_DS2 | `
Set-AzureRmVMOperatingSystem -Windows -ComputerName HostServerVM -Credential $Cred | `
Set-AzureRmVMSourceImage -PublisherName MicrosoftWindowsServer -Offer WindowsServer -Skus 2016-Datacenter -Version latest | `
Add-AzureRmVMNetworkInterface -Id $Nic.Id

}

$ErrorActionPreference = "Stop"
$VerbosePreference = "Continue"

Install-Module AzureRM

#https://docs.microsoft.com/en-us/azure/virtual-machines/windows/quick-create-powershell
Login-AzureRmAccount

New-AzureRmResourceGroup -Name ParcsResourceGroup -Location eastus

# Create a subnet configuration
$subnetConfig = New-AzureRmVirtualNetworkSubnetConfig -Name mySubnet -AddressPrefix 192.168.1.0/24

# Create a virtual network
$vnet = New-AzureRmVirtualNetwork -ResourceGroupName ParcsResourceGroup -Location eastus `
-Name MYvNET -AddressPrefix 192.168.0.0/16 -Subnet $subnetConfig

# Create a public IP address and specify a DNS name
$pip = New-AzureRmPublicIpAddress -ResourceGroupName ParcsResourceGroup -Location eastus `
-AllocationMethod Static -IdleTimeoutInMinutes 4 -Name "mypublicdns$(Get-Random)"

# Create an inbound network security group rule for ports
$nsgRuleRDP = New-AzureRmNetworkSecurityRuleConfig -Name nsgRuleRDP  -Protocol Tcp `
-Direction Inbound -Priority 1000 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
-DestinationPortRange 3389 -Access Allow

$nsgRuleWeb = New-AzureRmNetworkSecurityRuleConfig -Name nsgRuleWeb  -Protocol Tcp `
-Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
-DestinationPortRange 80 -Access Allow

$nsgRuleDaemon = New-AzureRmNetworkSecurityRuleConfig -Name nsgRuleDaemon  -Protocol Tcp `
-Direction Inbound -Priority 1002 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
-DestinationPortRange 2222 -Access Allow

$nsgRuleHostServer = New-AzureRmNetworkSecurityRuleConfig -Name nsgRuleHostServer  -Protocol Tcp `
-Direction Inbound -Priority 1003 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
-DestinationPortRange 1234 -Access Allow

$nsgRuleHostServerApi = New-AzureRmNetworkSecurityRuleConfig -Name nsgRuleHostServerApi  -Protocol Tcp `
-Direction Inbound -Priority 1004 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
-DestinationPortRange 1236 -Access Allow

# Create a network security group
$nsg = New-AzureRmNetworkSecurityGroup -ResourceGroupName ParcsResourceGroup -Location eastus `
-Name ParcsSecurityGroup -SecurityRules @($nsgRuleRDP,$nsgRuleWeb,$nsgRuleDaemon,$nsgRuleHostServer,$nsgRuleHostServerApi)

# Create a virtual network card and associate with public IP address and NSG
$nic = New-AzureRmNetworkInterface -Name myNic -ResourceGroupName ParcsResourceGroup -Location eastus `
-SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $pip.Id -NetworkSecurityGroupId $nsg.Id

# Define a credential object
# Username must be no longer than 20 characters and contain only alphanumeric characters
# The supplied password must be between 8-123 characters long and must satisfy 
# at least 3 of password complexity requirements from the following: 
# 1) Contains an uppercase character
# 2) Contains a lowercase character
# 3) Contains a numeric digit
# 4) Contains a special character.
$cred = Get-Credential

# Create a virtual machine configuration
$vmConfig = Create-VMConfig -VMName HostServerVM -Cred $cred -Nic $nic

New-AzureRmVM -ResourceGroupName ParcsResourceGroup -Location eastus -VM $vmConfig

Get-AzureRmPublicIpAddress -ResourceGroupName ParcsResourceGroup | Select IpAddress

