# PeerTubeApiClient.Model.Actor

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **int** |  | [optional] 
**Url** | **string** |  | [optional] 
**Name** | **string** | immutable name of the actor, used to find or mention it | [optional] 
**Avatars** | [**List&lt;ActorImage&gt;**](ActorImage.md) |  | [optional] 
**Host** | **string** | server on which the actor is resident | [optional] 
**HostRedundancyAllowed** | **bool** | whether this actor&#39;s host allows redundancy of its videos | [optional] 
**FollowingCount** | **int** | number of actors subscribed to by this actor, as seen by this instance | [optional] 
**FollowersCount** | **int** | number of followers of this actor, as seen by this instance | [optional] 
**CreatedAt** | **DateTime** |  | [optional] 
**UpdatedAt** | **DateTime** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

