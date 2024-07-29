# PeerTubeApiClient.Model.VideoUploadRequestCommon

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Video name | 
**ChannelId** | **int** | Channel id that will contain this video | 
**Privacy** | **VideoPrivacySet** |  | [optional] 
**Category** | **int** | category id of the video (see [/videos/categories](#operation/getCategories)) | [optional] 
**Licence** | **int** | licence id of the video (see [/videos/licences](#operation/getLicences)) | [optional] 
**Language** | **string** | language id of the video (see [/videos/languages](#operation/getLanguages)) | [optional] 
**Description** | **string** | Video description | [optional] 
**WaitTranscoding** | **bool** | Whether or not we wait transcoding before publish the video | [optional] 
**GenerateTranscription** | **bool** | **PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video | [optional] 
**Support** | **string** | A text tell the audience how to support the video creator | [optional] 
**Nsfw** | **bool** | Whether or not this video contains sensitive content | [optional] 
**Tags** | **List&lt;string&gt;** | Video tags (maximum 5 tags each between 2 and 30 characters) | [optional] 
**CommentsEnabled** | **bool** | Deprecated in 6.2, use commentsPolicy instead | [optional] 
**CommentsPolicy** | **VideoCommentsPolicySet** |  | [optional] 
**DownloadEnabled** | **bool** | Enable or disable downloading for this video | [optional] 
**OriginallyPublishedAt** | **DateTime** | Date when the content was originally published | [optional] 
**ScheduleUpdate** | [**VideoScheduledUpdate**](VideoScheduledUpdate.md) |  | [optional] 
**Thumbnailfile** | **System.IO.Stream** | Video thumbnail file | [optional] 
**Previewfile** | **System.IO.Stream** | Video preview file | [optional] 
**VideoPasswords** | **List&lt;string&gt;** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

