# PeerTubeApiClient.Model.VideoStreamingPlaylistsHLS

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PlaylistUrl** | **string** |  | [optional] 
**SegmentsSha256Url** | **string** |  | [optional] 
**Files** | [**List&lt;VideoFile&gt;**](VideoFile.md) | Video files associated to this playlist.  The difference with the root &#x60;files&#x60; property is that these files are fragmented, so they can be used in this streaming playlist (HLS, etc.)  | [optional] 
**Redundancies** | [**List&lt;VideoStreamingPlaylistsHLSRedundanciesInner&gt;**](VideoStreamingPlaylistsHLSRedundanciesInner.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

