# MathsLibrary
[![.NET Testing Workflow (Windows x64)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Windows.yml/badge.svg)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Windows.yml) [![.NET Testing Workflow (Windows ARM)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Windows%20ARM.yml/badge.svg)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Windows%20ARM.yml) [![.NET Testing Workflow (Mac Intel)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Mac%20Intel.yml/badge.svg)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Mac%20Intel.yml) [![.NET Testing Workflow (Mac ARM)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Mac%20ARM.yml/badge.svg)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Mac%20ARM.yml) [![.NET Testing Workflow (Linux x64)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Linux.yml/badge.svg)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Linux.yml) [![.NET Testing Workflow (Linux ARM)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Linux%20ARM.yml/badge.svg)](https://github.com/Nilonic/MathsLibrary/actions/workflows/Testing%20Workflow%20Linux%20ARM.yml)

## Blurb 'n stuff
MathsLibrary is a Library for C# applications (written in DotNet 8), which makes doing mathematical opereations simpler. 

If you need to clamp a number between two values, use either `MathsLibrary.Clamp.IClamp(value, min, max)` or `MathsLibrary.Clamp.EClamp(value, min, max)` (IClamp is Inclusive with Min and Max. EClamp is Exclusive with the Min and Max. Both IClamp and EClamp return either Int or Double)

If you need to convert, let's say, "Fourty Two Thousand and Fifty Five" to an int, use `MathsLibrary.NumFromText.WordsToNumber(value_string)` (returns a long. works up to quintillion)

The main exception we throw is `ArgumentException`.

## To Use
For the moment, the best way to use this is to download the repo, and add MathsLibrary as a Project Dependency. We will eventually release a library, once i get the workflow up and working, but updates will be on success of all workflows

## Contribution
If you wish to contribute to MathsLibrary, please extend and run the Testing file before submitting. If you don't, it makes it harder to ensure that everything works. When pushing, it'll test on `ubuntu-latest`, `windows-latest`, `ubuntu-24.04-arm`, `windows-11-arm`, `macos-13`, and `macos-latest` using the `Standard GitHub-hosted runners for public repositories`. We will only accept forks/pull requests that pass all these tests
