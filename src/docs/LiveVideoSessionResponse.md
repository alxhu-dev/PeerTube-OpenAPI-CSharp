# PeerTubeApiClient.Model.LiveVideoSessionResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **int** |  | [optional] 
**StartDate** | **DateTime** | Start date of the live session | [optional] 
**EndDate** | **DateTime?** | End date of the live session | [optional] 
**Error** | **int?** | Error type if an error occurred during the live session:   - &#x60;1&#x60;: Bad socket health (transcoding is too slow)   - &#x60;2&#x60;: Max duration exceeded   - &#x60;3&#x60;: Quota exceeded   - &#x60;4&#x60;: Quota FFmpeg error   - &#x60;5&#x60;: Video has been blacklisted during the live  | [optional] 
**ReplayVideo** | [**LiveVideoSessionResponseReplayVideo**](LiveVideoSessionResponseReplayVideo.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

