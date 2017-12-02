# Advent of Code 2017

My attempt to learn some F# by solving [Advent of Code 2017](https://adventofcode.com/2017)

## How to run

I use [Expecto](https://github.com/haf/expecto) with [.Net Core 2.0.3](https://github.com/dotnet/core/blob/master/release-notes/download-archives/2.0.3.md).
With dotnet core in place, you should be able to run with:

```
$ dotnet watch run
watch : Started
[22:47:04 INF] EXPECTO? Running tests... <Expecto>
[22:47:04 INF] EXPECTO! 9 tests run in 00:00:00.1352970 – 9 passed, 0 ignored, 0 failed, 0 errored. ᕙ໒( ˵ ಠ ╭͜ʖ╮ ಠೃ ˵ )७ᕗ <Expecto>
watch : Exited
watch : Waiting for a file to change before restarting dotnet...
```

Tests will rerun when files are modified when using the [dotnet watch](https://github.com/aspnet/DotNetTools/blob/dev/src/Microsoft.DotNet.Watcher.Tools/README.md) command.