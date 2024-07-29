# PeerTubeApiClient.Model.ApiV1RunnersJobsJobUUIDAcceptPost200ResponseJob

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Uuid** | **Guid** |  | [optional] 
**Type** | **RunnerJobType** |  | [optional] 
**State** | [**RunnerJobStateConstant**](RunnerJobStateConstant.md) |  | [optional] 
**Payload** | [**RunnerJobPayload**](RunnerJobPayload.md) |  | [optional] 
**Failures** | **int** | Number of times a remote runner failed to process this job. After too many failures, the job in \&quot;error\&quot; state | [optional] 
**Error** | **string** | Error message if the job is errored | [optional] 
**Progress** | **int** | Percentage progress | [optional] 
**Priority** | **int** | Job priority (less has more priority) | [optional] 
**UpdatedAt** | **DateTime** |  | [optional] 
**CreatedAt** | **DateTime** |  | [optional] 
**StartedAt** | **DateTime** |  | [optional] 
**FinishedAt** | **DateTime** |  | [optional] 
**Parent** | [**RunnerJobParent**](RunnerJobParent.md) |  | [optional] 
**Runner** | [**RunnerJobRunner**](RunnerJobRunner.md) |  | [optional] 
**JobToken** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

