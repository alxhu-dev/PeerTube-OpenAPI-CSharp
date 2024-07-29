# PeerTubeApiClient.Model.UserWithStats

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Account** | [**Account**](Account.md) |  | [optional] 
**AutoPlayNextVideo** | **bool** | Automatically start playing the upcoming video after the currently playing video | [optional] 
**AutoPlayNextVideoPlaylist** | **bool** | Automatically start playing the video on the playlist after the currently playing video | [optional] 
**AutoPlayVideo** | **bool** | Automatically start playing the video on the watch page | [optional] 
**Blocked** | **bool** |  | [optional] 
**BlockedReason** | **string** |  | [optional] 
**CreatedAt** | **string** |  | [optional] 
**Email** | **string** | The user email | [optional] 
**EmailVerified** | **bool** | Has the user confirmed their email address? | [optional] 
**Id** | **int** |  | [optional] [readonly] 
**PluginAuth** | **string** | Auth plugin to use to authenticate the user | [optional] 
**LastLoginDate** | **DateTime** |  | [optional] 
**NoInstanceConfigWarningModal** | **bool** |  | [optional] 
**NoAccountSetupWarningModal** | **bool** |  | [optional] 
**NoWelcomeModal** | **bool** |  | [optional] 
**NsfwPolicy** | **NSFWPolicy** |  | [optional] 
**Role** | [**UserRole**](UserRole.md) |  | [optional] 
**Theme** | **string** | Theme enabled by this user | [optional] 
**Username** | **string** | immutable name of the user, used to find or mention its actor | [optional] 
**VideoChannels** | [**List&lt;VideoChannel&gt;**](VideoChannel.md) |  | [optional] 
**VideoQuota** | **int** | The user video quota in bytes | [optional] 
**VideoQuotaDaily** | **int** | The user daily video quota in bytes | [optional] 
**P2pEnabled** | **bool** | Enable P2P in the player | [optional] 
**VideosCount** | **int** | Count of videos published | [optional] 
**AbusesCount** | **int** | Count of reports/abuses of which the user is a target | [optional] 
**AbusesAcceptedCount** | **int** | Count of reports/abuses created by the user and accepted/acted upon by the moderation team | [optional] 
**AbusesCreatedCount** | **int** | Count of reports/abuses created by the user | [optional] 
**VideoCommentsCount** | **int** | Count of comments published | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

