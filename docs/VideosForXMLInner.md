# PeerTubeApiClient.Model.VideosForXMLInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Link** | **string** | video watch page URL | [optional] 
**Guid** | **string** | video canonical URL | [optional] 
**PubDate** | **DateTime** | video publication date | [optional] 
**Description** | **string** | video description | [optional] 
**Contentencoded** | **string** | video description | [optional] 
**Dccreator** | **string** | publisher user name | [optional] 
**Mediacategory** | **int** | video category (MRSS) | [optional] 
**Mediacommunity** | [**VideosForXMLInnerMediaCommunity**](VideosForXMLInnerMediaCommunity.md) |  | [optional] 
**Mediaembed** | [**VideosForXMLInnerMediaEmbed**](VideosForXMLInnerMediaEmbed.md) |  | [optional] 
**Mediaplayer** | [**VideosForXMLInnerMediaPlayer**](VideosForXMLInnerMediaPlayer.md) |  | [optional] 
**Mediathumbnail** | [**VideosForXMLInnerMediaThumbnail**](VideosForXMLInnerMediaThumbnail.md) |  | [optional] 
**Mediatitle** | **string** | see [media:title](https://www.rssboard.org/media-rss#media-title) (MRSS). We only use &#x60;plain&#x60; titles. | [optional] 
**Mediadescription** | **string** |  | [optional] 
**Mediarating** | **string** | see [media:rating](https://www.rssboard.org/media-rss#media-rating) (MRSS) | [optional] 
**Enclosure** | [**VideosForXMLInnerEnclosure**](VideosForXMLInnerEnclosure.md) |  | [optional] 
**Mediagroup** | [**List&lt;VideosForXMLInnerMediaGroupInner&gt;**](VideosForXMLInnerMediaGroupInner.md) | list of streamable files for the video. see [media:peerLink](https://www.rssboard.org/media-rss#media-peerlink) and [media:content](https://www.rssboard.org/media-rss#media-content) or  (MRSS) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

