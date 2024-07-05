# Custom Code for the MultiPartFormDataParser component in OutSystems

## Description

Helper action used to parse MultiPart/Form-Data responses from a binary blob.

It can receive a boundary value, or attempt to identify the boundary based on the provided content.

The response will be converted to a list of Parts.

![Extension Content][imglink]

## How to use

To use the component you need to pass in a binary with your Multipart/Form-Data content.

It's recommended to retrieve the Multipart/Form-Data from the response header, however, if no value is passed, the component will attempt to retrieve the boundary based on the content provided.

Additionally, you can optionally pass in a different encoding in case the data provided was sent using a different encoding,

If successful, a list of parts will be returned with the different parts of the payload.

[imglink]: ./MultipartFormDataParser/resources/MultipartFormDataParser.png