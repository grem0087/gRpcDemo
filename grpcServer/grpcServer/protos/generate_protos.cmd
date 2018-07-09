@rem Copyright 2016 gRPC authors.
@rem
@rem Licensed under the Apache License, Version 2.0 (the "License");
@rem you may not use this file except in compliance with the License.
@rem You may obtain a copy of the License at
@rem
@rem     http://www.apache.org/licenses/LICENSE-2.0
@rem
@rem Unless required by applicable law or agreed to in writing, software
@rem distributed under the License is distributed on an "AS IS" BASIS,
@rem WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
@rem See the License for the specific language governing permissions and
@rem limitations under the License.

@rem Generate the C# code for .proto files

setlocal

@rem enter this directory
cd /d %~dp0

set TOOLS_PATH=%userprofile%\.nuget\packages\grpc.tools\1.8.0\tools\windows_x64

%TOOLS_PATH%\protoc.exe  --proto_path=./../../../protos/ --csharp_out .  --grpc_out=no_client:. --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe realtyServiceTypes.proto
%TOOLS_PATH%\protoc.exe --proto_path=./../../../protos/ --csharp_out .  --grpc_out=no_client:. --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe realtyService.proto

endlocal
