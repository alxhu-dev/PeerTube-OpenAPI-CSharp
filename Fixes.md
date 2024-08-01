# Fixes for build errors
* Several files have broken XML comments.
* The class `Guid` has been recreated, see `Guid.cs` in `src/PeerTubeApiClient`.
* Every reference to a class named `Uuid` is changed to `Guid`.
* Some custom `JsonConverter` have redundant switch cases which have been shrinked to one.