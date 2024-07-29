# PeerTubeApiClient.Model.VideoChannelListDataInner

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
**DisplayName** | **string** | editable name of the channel, displayed in its representations | [optional] 
**Description** | **string** |  | [optional] 
**Support** | **string** | text shown by default on all videos of this channel, to tell the audience how to support it | [optional] 
**IsLocal** | **bool** |  | [optional] [readonly] 
**Banners** | [**List&lt;ActorImage&gt;**](ActorImage.md) |  | [optional] 
**OwnerAccount** | [**Account**](Account.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

