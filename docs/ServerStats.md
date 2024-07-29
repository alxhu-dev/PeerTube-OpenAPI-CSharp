# PeerTubeApiClient.Model.ServerStats

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TotalUsers** | **decimal** |  | [optional] 
**TotalDailyActiveUsers** | **decimal** |  | [optional] 
**TotalWeeklyActiveUsers** | **decimal** |  | [optional] 
**TotalMonthlyActiveUsers** | **decimal** |  | [optional] 
**TotalModerators** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled total moderators stats | [optional] 
**TotalAdmins** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled total admins stats | [optional] 
**TotalLocalVideos** | **decimal** |  | [optional] 
**TotalLocalVideoViews** | **decimal** | Total video views made on the instance | [optional] 
**TotalLocalVideoComments** | **decimal** | Total comments made by local users | [optional] 
**TotalLocalVideoFilesSize** | **decimal** |  | [optional] 
**TotalVideos** | **decimal** |  | [optional] 
**TotalVideoComments** | **decimal** |  | [optional] 
**TotalLocalVideoChannels** | **decimal** |  | [optional] 
**TotalLocalDailyActiveVideoChannels** | **decimal** |  | [optional] 
**TotalLocalWeeklyActiveVideoChannels** | **decimal** |  | [optional] 
**TotalLocalMonthlyActiveVideoChannels** | **decimal** |  | [optional] 
**TotalLocalPlaylists** | **decimal** |  | [optional] 
**TotalInstanceFollowers** | **decimal** |  | [optional] 
**TotalInstanceFollowing** | **decimal** |  | [optional] 
**VideosRedundancy** | [**List&lt;ServerStatsVideosRedundancyInner&gt;**](ServerStatsVideosRedundancyInner.md) |  | [optional] 
**TotalActivityPubMessagesProcessed** | **decimal** |  | [optional] 
**TotalActivityPubMessagesSuccesses** | **decimal** |  | [optional] 
**TotalActivityPubMessagesErrors** | **decimal** |  | [optional] 
**ActivityPubMessagesProcessedPerSecond** | **decimal** |  | [optional] 
**TotalActivityPubMessagesWaiting** | **decimal** |  | [optional] 
**AverageRegistrationRequestResponseTimeMs** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats | [optional] 
**TotalRegistrationRequestsProcessed** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats | [optional] 
**TotalRegistrationRequests** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats | [optional] 
**AverageAbuseResponseTimeMs** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats | [optional] 
**TotalAbusesProcessed** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats | [optional] 
**TotalAbuses** | **decimal** | **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

