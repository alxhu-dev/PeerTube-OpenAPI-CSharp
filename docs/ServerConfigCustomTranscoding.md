# PeerTubeApiClient.Model.ServerConfigCustomTranscoding
Settings pertaining to transcoding jobs

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Enabled** | **bool** |  | [optional] 
**OriginalFile** | [**ServerConfigCustomTranscodingOriginalFile**](ServerConfigCustomTranscodingOriginalFile.md) |  | [optional] 
**AllowAdditionalExtensions** | **bool** | Allow your users to upload .mkv, .mov, .avi, .wmv, .flv, .f4v, .3g2, .3gp, .mts, m2ts, .mxf, .nut videos | [optional] 
**AllowAudioFiles** | **bool** | If a user uploads an audio file, PeerTube will create a video by merging the preview file and the audio file | [optional] 
**Threads** | **int** | Amount of threads used by ffmpeg for 1 transcoding job | [optional] 
**Concurrency** | **decimal** | Amount of transcoding jobs to execute in parallel | [optional] 
**Profile** | **string** | New profiles can be added by plugins ; available in core PeerTube: &#39;default&#39;.  | [optional] 
**Resolutions** | [**ServerConfigCustomTranscodingResolutions**](ServerConfigCustomTranscodingResolutions.md) |  | [optional] 
**WebVideos** | [**ServerConfigCustomTranscodingWebVideos**](ServerConfigCustomTranscodingWebVideos.md) |  | [optional] 
**Hls** | [**ServerConfigCustomTranscodingHls**](ServerConfigCustomTranscodingHls.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

