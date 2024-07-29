# PeerTubeApiClient.Model.UserViewingVideo

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CurrentTime** | **int** | timestamp within the video, in seconds | 
**ViewEvent** | **string** | Event since last viewing call:  * &#x60;seek&#x60; - If the user seeked the video  | [optional] 
**SessionId** | **string** | Optional param to represent the current viewer session. Used by the backend to properly count one view per session per video. PeerTube admin can configure the server to not trust this &#x60;sessionId&#x60; parameter but use the request IP address instead to identify a viewer.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

