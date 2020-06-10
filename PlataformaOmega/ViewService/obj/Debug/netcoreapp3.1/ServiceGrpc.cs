// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gRPC/Server/Protos/service.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ViewService.gRPC.Server.Protos {
  public static partial class View
  {
    static readonly string __ServiceName = "View";

    static readonly grpc::Marshaller<global::ViewService.gRPC.Server.Protos.GrpcGetViewRequest> __Marshaller_GrpcGetViewRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ViewService.gRPC.Server.Protos.GrpcGetViewRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::ViewService.gRPC.Server.Protos.GrpcViewAsString> __Marshaller_GrpcViewAsString = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ViewService.gRPC.Server.Protos.GrpcViewAsString.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::ViewService.gRPC.Server.Protos.GrpcGetStaticFileRequest> __Marshaller_GrpcGetStaticFileRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ViewService.gRPC.Server.Protos.GrpcGetStaticFileRequest.Parser.ParseFrom);

    static readonly grpc::Method<global::ViewService.gRPC.Server.Protos.GrpcGetViewRequest, global::ViewService.gRPC.Server.Protos.GrpcViewAsString> __Method_GetView = new grpc::Method<global::ViewService.gRPC.Server.Protos.GrpcGetViewRequest, global::ViewService.gRPC.Server.Protos.GrpcViewAsString>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetView",
        __Marshaller_GrpcGetViewRequest,
        __Marshaller_GrpcViewAsString);

    static readonly grpc::Method<global::ViewService.gRPC.Server.Protos.GrpcGetStaticFileRequest, global::ViewService.gRPC.Server.Protos.GrpcViewAsString> __Method_GetStaticFile = new grpc::Method<global::ViewService.gRPC.Server.Protos.GrpcGetStaticFileRequest, global::ViewService.gRPC.Server.Protos.GrpcViewAsString>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetStaticFile",
        __Marshaller_GrpcGetStaticFileRequest,
        __Marshaller_GrpcViewAsString);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ViewService.gRPC.Server.Protos.ServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of View</summary>
    [grpc::BindServiceMethod(typeof(View), "BindService")]
    public abstract partial class ViewBase
    {
      public virtual global::System.Threading.Tasks.Task<global::ViewService.gRPC.Server.Protos.GrpcViewAsString> GetView(global::ViewService.gRPC.Server.Protos.GrpcGetViewRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::ViewService.gRPC.Server.Protos.GrpcViewAsString> GetStaticFile(global::ViewService.gRPC.Server.Protos.GrpcGetStaticFileRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ViewBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetView, serviceImpl.GetView)
          .AddMethod(__Method_GetStaticFile, serviceImpl.GetStaticFile).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ViewBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetView, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ViewService.gRPC.Server.Protos.GrpcGetViewRequest, global::ViewService.gRPC.Server.Protos.GrpcViewAsString>(serviceImpl.GetView));
      serviceBinder.AddMethod(__Method_GetStaticFile, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ViewService.gRPC.Server.Protos.GrpcGetStaticFileRequest, global::ViewService.gRPC.Server.Protos.GrpcViewAsString>(serviceImpl.GetStaticFile));
    }

  }
}
#endregion