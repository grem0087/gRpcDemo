// GENERATED CODE -- DO NOT EDIT!

'use strict';
var grpc = require('grpc');
var realtyService_pb = require('./realtyService_pb.js');
var realtyServiceTypes_pb = require('./realtyServiceTypes_pb.js');

function serialize_RealtyListRequest(arg) {
  if (!(arg instanceof realtyService_pb.RealtyListRequest)) {
    throw new Error('Expected argument of type RealtyListRequest');
  }
  return new Buffer(arg.serializeBinary());
}

function deserialize_RealtyListRequest(buffer_arg) {
  return realtyService_pb.RealtyListRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_RealtyListResponse(arg) {
  if (!(arg instanceof realtyService_pb.RealtyListResponse)) {
    throw new Error('Expected argument of type RealtyListResponse');
  }
  return new Buffer(arg.serializeBinary());
}

function deserialize_RealtyListResponse(buffer_arg) {
  return realtyService_pb.RealtyListResponse.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_RealtyRequest(arg) {
  if (!(arg instanceof realtyService_pb.RealtyRequest)) {
    throw new Error('Expected argument of type RealtyRequest');
  }
  return new Buffer(arg.serializeBinary());
}

function deserialize_RealtyRequest(buffer_arg) {
  return realtyService_pb.RealtyRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_RealtyResponse(arg) {
  if (!(arg instanceof realtyService_pb.RealtyResponse)) {
    throw new Error('Expected argument of type RealtyResponse');
  }
  return new Buffer(arg.serializeBinary());
}

function deserialize_RealtyResponse(buffer_arg) {
  return realtyService_pb.RealtyResponse.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_UserRequest(arg) {
  if (!(arg instanceof realtyService_pb.UserRequest)) {
    throw new Error('Expected argument of type UserRequest');
  }
  return new Buffer(arg.serializeBinary());
}

function deserialize_UserRequest(buffer_arg) {
  return realtyService_pb.UserRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_UserResponse(arg) {
  if (!(arg instanceof realtyService_pb.UserResponse)) {
    throw new Error('Expected argument of type UserResponse');
  }
  return new Buffer(arg.serializeBinary());
}

function deserialize_UserResponse(buffer_arg) {
  return realtyService_pb.UserResponse.deserializeBinary(new Uint8Array(buffer_arg));
}


var DowntownRealtyService = exports.DowntownRealtyService = {
  getRealtyById: {
    path: '/DowntownRealty/GetRealtyById',
    requestStream: false,
    responseStream: false,
    requestType: realtyService_pb.RealtyRequest,
    responseType: realtyService_pb.RealtyResponse,
    requestSerialize: serialize_RealtyRequest,
    requestDeserialize: deserialize_RealtyRequest,
    responseSerialize: serialize_RealtyResponse,
    responseDeserialize: deserialize_RealtyResponse,
  },
  getRealtyList: {
    path: '/DowntownRealty/GetRealtyList',
    requestStream: false,
    responseStream: false,
    requestType: realtyService_pb.RealtyListRequest,
    responseType: realtyService_pb.RealtyListResponse,
    requestSerialize: serialize_RealtyListRequest,
    requestDeserialize: deserialize_RealtyListRequest,
    responseSerialize: serialize_RealtyListResponse,
    responseDeserialize: deserialize_RealtyListResponse,
  },
  getUserById: {
    path: '/DowntownRealty/GetUserById',
    requestStream: false,
    responseStream: false,
    requestType: realtyService_pb.UserRequest,
    responseType: realtyService_pb.UserResponse,
    requestSerialize: serialize_UserRequest,
    requestDeserialize: deserialize_UserRequest,
    responseSerialize: serialize_UserResponse,
    responseDeserialize: deserialize_UserResponse,
  },
};

exports.DowntownRealtyClient = grpc.makeGenericClientConstructor(DowntownRealtyService);
