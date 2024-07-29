# Fixes for build errors
## `Model`
### `AddPlaylist200ResponseVideoPlaylist.cs`
* Function `IValidatableObject.Validate(ValidationContext validationContext)` has unnecessary UUID length validations
    * Fix: Remove length validations
### `Video.cs`
* Property `TruncatedDescription` has broken XML comment
    * Fix: Add prefix
* Function `IValidatableObject.Validate(ValidationContext validationContext)` has unnecessary UUID length validations
    * Fix: Remove length validations
### `VideoDetails.cs`
* Property `Description` has broken XML comment
    * Fix: Add prefix
* Property `TruncatedDescription` has broken XML comment
    * Fix: Add prefix
* Function `IValidatableObject.Validate(ValidationContext validationContext)` has unnecessary UUID length validations
    * Fix: Remove length validations
### `VideoUploadRequestCommon.cs`
* Property `Description` has broken XML comment
    * Fix: Add prefix
### `VideoUploadRequestResumable.cs`
* Property `Description` has broken XML comment
    * Fix: Add prefix