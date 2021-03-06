# gRpcDemo
+ gRpcClient - console grpc client
+ gRpcServer console grpc server
+ NodeReact - node client example

 ```protobuf
syntax = "proto3";

option csharp_namespace = "DowntownRealty";

enum RealtyType{
    HOUSE = 0;
    APARTMENTS = 1;
    COMERCIAL = 2;
}

message User{
	int32  id = 1;
	string name = 2;
	string email = 3;
	string phone = 4;
}

message RealtyAd{
	int32  id = 1;
	RealtyType type =2;
	string topic = 3;
	string message  = 4;
	string phone = 5;
}

message  RealtyRequest{
	int64 id = 1;
}

message  RealtyListRequest{
	RealtyType type = 1;
}

message  UserRequest{
	int64 id = 1;
}

message  RealtyResponse{
	RealtyAd message = 1;
}

message  RealtyListResponse{
	repeated RealtyAd realties = 1;
}

message  UserResponse{
	User user = 1;
}

service DowntownRealty{
    rpc GetRealtyById (RealtyRequest) returns (RealtyResponse);
	rpc GetRealtyList (RealtyListRequest) returns (RealtyListResponse);
	rpc GetUserById (UserRequest) returns (UserResponse);
}
```
