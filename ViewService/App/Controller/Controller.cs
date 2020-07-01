using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewService.gRPC.Server.Protos;
using ViewService.App.ControllerTypeAdapters;
using ViewService.App.UseCases;

namespace ViewService.App
{
    public class Controller
    {
        public static async Task<GrpcViewAsString> GetViewAsync(GrpcGetViewRequest request)
        {
            try
            {
                var path = GrpcGetViewReqAdapter.GetPath(request);
                var view = await UseCaseOperator.GetViewAsync(path);
                return Presenter.PresentViewAsString(view);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcViewAsString> GetStaticFileAsync(GrpcGetStaticFileRequest request)
        {
            try
            {
                var path = GrpcGetStaticFileRequestAdapter.GetPath(request);
                var view = await UseCaseOperator.GetStaticFileAsync(path);
                return Presenter.PresentViewAsString(view);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
