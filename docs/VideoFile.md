# PeerTubeApiClient.Model.VideoFile

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **int** |  | [optional] 
**MagnetUri** | **string** | magnet URI allowing to resolve the video via BitTorrent without a metainfo file | [optional] 
**Resolution** | [**VideoResolutionConstant**](VideoResolutionConstant.md) |  | [optional] 
**Size** | **int** | Video file size in bytes | [optional] 
**TorrentUrl** | **string** | Direct URL of the torrent file | [optional] 
**TorrentDownloadUrl** | **string** | URL endpoint that transfers the torrent file as an attachment (so that the browser opens a download dialog) | [optional] 
**FileUrl** | **string** | Direct URL of the video | [optional] 
**FileDownloadUrl** | **string** | URL endpoint that transfers the video file as an attachment (so that the browser opens a download dialog) | [optional] 
**Fps** | **decimal** | Frames per second of the video file | [optional] 
**Width** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Video stream width | [optional] 
**Height** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Video stream height | [optional] 
**MetadataUrl** | **string** | URL dereferencing the output of ffprobe on the file | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

