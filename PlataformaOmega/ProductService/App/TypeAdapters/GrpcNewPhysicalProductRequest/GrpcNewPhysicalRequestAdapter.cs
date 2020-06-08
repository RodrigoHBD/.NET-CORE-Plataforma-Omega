using ProductService.App.Models;
using ProductService.App.Models.Input;
using ProductService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.TypeAdapters.GrpcNewPhysicalProductRequest
{
    public class GrpcNewPhysicalRequestAdapter
    {
        public static ICreateNewPhysicalProductRequest Adapt(GrpcNewPhysicalProduct grpcRequest)
        {
            try
            {
                var request = new CreateNewPhysicalProductRequest()
                {
                    Brand = grpcRequest.ProductData.Brand,
                    Name = grpcRequest.ProductData.Name,
                    Description = grpcRequest.ProductData.Description,
                    Model = grpcRequest.ProductData.Model,
                    Weight = grpcRequest.Weight
                };

                DetermineCategory(grpcRequest, request);
                DetermineColor(grpcRequest, request);
                DetermineCondition(grpcRequest, request);
                BuildWarranty(grpcRequest, request);
                BuildMeasurements(grpcRequest, request);

                return request;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private static void BuildWarranty(GrpcNewPhysicalProduct grpcRequest, CreateNewPhysicalProductRequest request)
        {
            try
            {
                request.Warranty = new ProductWarranty()
                {
                    TimeInDays = grpcRequest.WarrantyTimeInDays
                };
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private static void BuildMeasurements(GrpcNewPhysicalProduct grpcRequest, CreateNewPhysicalProductRequest request)
        {
            try
            {
                request.Mesuarments = new PhysicalProductMeasurements()
                {
                    Width = grpcRequest.Width,
                    Height = grpcRequest.Height,
                    Length = grpcRequest.Length
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void DetermineCategory(GrpcNewPhysicalProduct grpcRequest, CreateNewPhysicalProductRequest request)
        {
            try
            {
                if (grpcRequest.ProductData.Category == "")
                {

                }
                request.Category = ProductCategory.Teste;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void DetermineColor(GrpcNewPhysicalProduct grpcRequest, CreateNewPhysicalProductRequest request)
        {
            try
            {
                if (grpcRequest.ProductData.Color == "white")
                {
                    request.Color = ProductColor.White;
                }
                else if (grpcRequest.ProductData.Color == "black")
                {
                    request.Color = ProductColor.Black;
                }
                else
                {
                    request.Color = ProductColor.Invalid;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void DetermineCondition(GrpcNewPhysicalProduct grpcRequest, CreateNewPhysicalProductRequest request)
        {
            try
            {
                if (grpcRequest.ProductData.Condition == "new")
                {
                    request.Condition = ProductCondition.New;
                }
                else if (grpcRequest.ProductData.Condition == "used")
                {
                    request.Condition = ProductCondition.Used;
                }
                else
                {
                    request.Condition = ProductCondition.Invalid;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

    public class CreateNewPhysicalProductRequest : ICreateNewPhysicalProductRequest
    {
        public double Weight { get; set; }

        public PhysicalProductMeasurements Mesuarments { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProductCategory Category { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public ProductColor Color { get; set; }

        public ProductCondition Condition { get; set; }

        public List<string> PicturesUrls { get; set; }

        public ProductWarranty Warranty { get; set; }
    }
}
