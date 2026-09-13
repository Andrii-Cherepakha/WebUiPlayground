#!/usr/bin/env pwsh

# C:\Users\user\AppData\Local\ms-playwright\
# pwsh runtest.ps1

# $env:HEADED="1"
# $env:BROWSER="webkit"

#dotnet test --filter "PlayWrightTests.SomeTest"

dotnet test --filter "ElementInteractionTest.OverlappedElement" --settings:Settings\chrome.runsettings