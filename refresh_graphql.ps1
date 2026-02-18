Clear-Host;

$services = @(
    @{ Name='Downstream'; Path='FusionBug.Downstream'; SchemaName='downstream.fsp' }
)
$location = Get-Location
try {
    $arguments = @()
    foreach ($target in $services)
    {
        Write-Host ----------- $target.Name -----------
        $path = Join-Path -Path $PSScriptRoot -ChildPath $target.Path
        if (-not (Test-Path -Path $path)) {
           Write-Error "failed to find path " $path
           Break
        } 
        Set-Location $path
    
        Write-Host "Building $($path)" -ForegroundColor "Magenta";
        dotnet run -- schema export --output schema.graphql
        if ($LASTEXITCODE -ne 0) {
            Write-Error "error building " $projectName
            Break
        }
        fusion subgraph pack
        if ($LASTEXITCODE -ne 0) {
            Write-Error "error packing " $projectName
            Break
        }
        $arguments += '-s'
        $arguments += "$($target.Path)/$($target.SchemaName)"
    }
    Write-Host @arguments
    Set-Location $PSScriptRoot

    Write-Host "Generating gateway.fgp..."
    rm "$($PSScriptRoot)/gateway.fgp" | Out-Null
    fusion compose -p "$($PSScriptRoot)/gateway.fgp" @arguments
    if ($LASTEXITCODE -ne 0) {
        Write-Error "error generating fusion compose " $projectName
        Break
    }
}
catch {
    Write-Host "An error occurred:"
    Write-Host "Error Message: $($PSItem.Exception.Message)"
    Write-Host "Error Type: $($PSItem.Exception.GetType().FullName)"
    Write-Host "Script Line: $($PSItem.InvocationInfo.ScriptLineNumber)"
}
finally {
    Set-Location $location
}