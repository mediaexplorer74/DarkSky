﻿using Newtonsoft.Json;

namespace BlueSky.Core
{
  public class Blob
  {
    [JsonProperty("ref")]
    public object reference = null;
    public string mimeType = string.Empty;
    public uint size = 0;
    public string cid = null;
  }
}