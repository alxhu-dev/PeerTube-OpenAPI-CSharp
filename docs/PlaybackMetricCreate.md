# PeerTubeApiClient.Model.PlaybackMetricCreate

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PlayerMode** | **string** |  | 
**Resolution** | **decimal** | Current player video resolution | [optional] 
**Fps** | **decimal** | Current player video fps | [optional] 
**P2pEnabled** | **bool** |  | 
**P2pPeers** | **decimal** | P2P peers connected (doesn&#39;t include WebSeed peers) | [optional] 
**ResolutionChanges** | **decimal** | How many resolution changes occurred since the last metric creation | 
**Errors** | **decimal** | How many errors occurred since the last metric creation | 
**DownloadedBytesP2P** | **decimal** | How many bytes were downloaded with P2P since the last metric creation | 
**DownloadedBytesHTTP** | **decimal** | How many bytes were downloaded with HTTP since the last metric creation | 
**UploadedBytesP2P** | **decimal** | How many bytes were uploaded with P2P since the last metric creation | 
**VideoId** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

