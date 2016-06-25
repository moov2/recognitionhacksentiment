# re:cognition hack sentiment

This is a hack project for [re:cognition hack](https://twitter.com/recognitionhack) that fetches tweets with the `#recognitionhack` hash tag and runs them through the sentiment analysis tool offered by [Microsoft cognitive services](https://www.microsoft.com/cognitive-services/en-us/text-analytics-api).

You can see this hack in action at the link below.

[https://github.com/moov2/recognitionhacksentiment](https://github.com/moov2/recognitionhacksentiment)

## Setup

To get this running locally you will need to add an `AppSettings.config` file to the root of the web project. This file requires a Microsoft cognitive services API key (requires a Microsoft account) and Twitter API consumer key and secret (requires a Twitter account). Below is a preview of the `AppSettings.config` file.

```
<?xml version="1.0" encoding="utf-8"?>
<appSettings>
  <add key="webpages:Version" value="3.0.0.0" />
  <add key="webpages:Enabled" value="false" />
  <add key="ClientValidationEnabled" value="true" />
  <add key="UnobtrusiveJavaScriptEnabled" value="true" />

  <!-- Custom Properties -->
  <add key="TextApiKey" value="<Your Microsoft cognitive services text API key>"/>
  <add key="TwitterConsumerKey" value="<Your Twitter consumer key>"/>
  <add key="TwitterConsumerSecret" value="<Your Twitter consumer secret>"/>
</appSettings>
```
