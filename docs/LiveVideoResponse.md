# PeerTubeApiClient.Model.LiveVideoResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RtmpUrl** | **string** | Included in the response if an appropriate token is provided | [optional] 
**RtmpsUrl** | **string** | Included in the response if an appropriate token is provided | [optional] 
**StreamKey** | **string** | RTMP stream key to use to stream into this live video. Included in the response if an appropriate token is provided | [optional] 
**SaveReplay** | **bool** |  | [optional] 
**ReplaySettings** | [**LiveVideoReplaySettings**](LiveVideoReplaySettings.md) |  | [optional] 
**PermanentLive** | **bool** | User can stream multiple times in a permanent live | [optional] 
**LatencyMode** | **LiveVideoLatencyMode** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

