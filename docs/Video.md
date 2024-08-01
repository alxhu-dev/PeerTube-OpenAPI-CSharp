# PeerTubeApiClient.Model.Video

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **int** | object id for the video | [optional] 
**Uuid** | **Guid** | universal identifier for the video, that can be used across instances | [optional] 
**ShortUUID** | **string** | translation of a uuid v4 with a bigger alphabet to have a shorter uuid | [optional] 
**IsLive** | **bool** |  | [optional] 
**CreatedAt** | **DateTime** | time at which the video object was first drafted | [optional] 
**PublishedAt** | **DateTime** | time at which the video was marked as ready for playback (with restrictions depending on &#x60;privacy&#x60;). Usually set after a &#x60;state&#x60; evolution. | [optional] 
**UpdatedAt** | **DateTime** | last time the video&#39;s metadata was modified | [optional] 
**OriginallyPublishedAt** | **DateTime?** | used to represent a date of first publication, prior to the practical publication date of &#x60;publishedAt&#x60; | [optional] 
**Category** | [**VideoConstantNumberCategory**](VideoConstantNumberCategory.md) | category in which the video is classified | [optional] 
**Licence** | [**VideoConstantNumberLicence**](VideoConstantNumberLicence.md) | licence under which the video is distributed | [optional] 
**Language** | [**VideoConstantStringLanguage**](VideoConstantStringLanguage.md) | main language used in the video | [optional] 
**Privacy** | [**VideoPrivacyConstant**](VideoPrivacyConstant.md) | privacy policy used to distribute the video | [optional] 
**TruncatedDescription** | **string** | truncated description of the video, written in Markdown.  | [optional] 
**Duration** | **int** | duration of the video in seconds | [optional] 
**AspectRatio** | **float?** | **PeerTube &gt;&#x3D; 6.1** Aspect ratio of the video stream | [optional] 
**IsLocal** | **bool** |  | [optional] 
**Name** | **string** | title of the video | [optional] 
**ThumbnailPath** | **string** |  | [optional] 
**PreviewPath** | **string** |  | [optional] 
**EmbedPath** | **string** |  | [optional] 
**Views** | **int** |  | [optional] 
**Likes** | **int** |  | [optional] 
**Dislikes** | **int** |  | [optional] 
**Nsfw** | **bool** |  | [optional] 
**WaitTranscoding** | **bool?** |  | [optional] 
**State** | [**VideoStateConstant**](VideoStateConstant.md) | represents the internal state of the video processing within the PeerTube instance | [optional] 
**ScheduledUpdate** | [**VideoScheduledUpdate**](VideoScheduledUpdate.md) |  | [optional] 
**Blacklisted** | **bool?** |  | [optional] 
**BlacklistedReason** | **string** |  | [optional] 
**Account** | [**AccountSummary**](AccountSummary.md) |  | [optional] 
**Channel** | [**VideoChannelSummary**](VideoChannelSummary.md) |  | [optional] 
**UserHistory** | [**VideoUserHistory**](VideoUserHistory.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

