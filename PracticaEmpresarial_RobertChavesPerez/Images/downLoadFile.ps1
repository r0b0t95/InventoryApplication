
param(
    [string]$url,
    [string]$file
)

if(-Not [string]::IsNullOrEmpty($url) -and -Not [string]::IsNullOrEmpty($file)){

    $path = 'D:\PracticaEmpresarial\C#APP_&_DatabasSQLSERVER_\PracticaEmpresarial_RobertChavesPerez\PracticaEmpresarial_RobertChavesPerez\Images\' + $file

    Invoke-WebRequest -Uri $url -Outfile $path 

    Write-Host "[+] Exit..."

}else{

    Write-Host "[-] Error... \n please insert 2 arguments :("

}