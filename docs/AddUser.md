# PeerTubeApiClient.Model.AddUser

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Username** | **string** | immutable name of the user, used to find or mention its actor | 
**Password** | **string** |  | 
**Email** | **string** | The user email | 
**VideoQuota** | **int** | The user video quota in bytes | [optional] 
**VideoQuotaDaily** | **int** | The user daily video quota in bytes | [optional] 
**ChannelName** | **string** | immutable name of the channel, used to interact with its actor | [optional] 
**Role** | [**UserRole**](UserRole.md) |  | 
**AdminFlags** | **UserAdminFlags** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

