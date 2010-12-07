param($installPath, $toolsPath, $package, $project)

$global:funqletPath = $installPath
$global:funqletTools = $toolsPath
Write-Host installPath=$global:funqletPath, toolsPath=$global:funqletTools

function global:Add-Funqlet {
    [CmdletBinding()]
    param ([string]$project)
    Process {
        # 
		Write-Host Added to $project
    }
}
