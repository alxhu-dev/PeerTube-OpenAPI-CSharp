# PeerTubeApiClient.Model.VideoImport

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **int** |  | [optional] [readonly] 
**TargetUrl** | **string** | remote URL where to find the import&#39;s source video | [optional] 
**MagnetUri** | **string** | magnet URI allowing to resolve the import&#39;s source video | [optional] 
**Torrentfile** | **System.IO.Stream** | Torrent file containing only the video file | [optional] 
**TorrentName** | **string** |  | [optional] [readonly] 
**State** | [**VideoImportStateConstant**](VideoImportStateConstant.md) |  | [optional] [readonly] 
**Error** | **string** |  | [optional] [readonly] 
**CreatedAt** | **DateTime** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**Video** | [**Video**](Video.md) |  | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

