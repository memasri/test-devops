# Author: Mia El-Masri
# Purpose: This script will fetch the top 5 albums with the most photos in descending order

# This function will take an album id as parameter and return the amount of photos in that album
function Get-AlbumPhotoCount {
    param(
        [string] $albumId
    )

    $uri = "http://jsonplaceholder.typicode.com/photos"

    $photos = Invoke-RestMethod -Method Get -Uri $uri
    $amount = $photos | Where-Object { $_.albumId -eq $albumId}

    return $amount.Count
}
# This function will return a list of albums
function Get-Albums {
    $uri = "http://jsonplaceholder.typicode.com/albums"
    
    $albums = Invoke-RestMethod -Method Get -Uri $uri

    return $albums
}

$collection = @()

$albums = Get-Albums

foreach ($album in $albums) 
{
    $collection += [PSCustomObject]@{
        AlbumId    = $album.id
        AlbumTitle = $album.title
        PhotoCount = Get-AlbumPhotoCount -albumId $album.id
    }
}

$collection | Sort-Object PhotoCount -Descending | Select-Object -First 5
