﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Hisar.Component.CoreManagement.Helpers;
using Hisar.Component.CoreManagement.Models;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using NetCoreStack.Hisar;

namespace Hisar.Component.CoreManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly HisarAssemblyComponentsLoader _assemblyLoader;
        private readonly ApplicationPartManager _partManager;
        private readonly List<IApplicationModelProvider> _providers;
        private readonly ComponentModelBuilderHelper _componentModelBuilderHelper;

        public HomeController(HisarAssemblyComponentsLoader assemblyLoader,
            ApplicationPartManager partManager,
            IEnumerable<IApplicationModelProvider> providers,
            IActionDescriptorProvider actionDescriptorProvider)
        {
            _assemblyLoader = assemblyLoader;
            _partManager = partManager;
            _providers = providers.ToList();

            _componentModelBuilderHelper = new ComponentModelBuilderHelper(partManager, _providers);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ComponentList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAssemblies()
        {
            #region SampleClass
            /* Sample Class
            var assemblyList = new List<AssemblyDescriptor>()
            {
                new AssemblyDescriptor()
                {
                    PackageId= "CarouselApp",
                    PackageVersion= "1.2.3.4",
                    Authors= "Gencebay Demir",
                    Company= "Bilge Adam Bilişim Hiz. Ltd. Şti.",
                    Description= "NetcoreStack Hisar Carousel",
                    Copyright= "Opengl Licence",
                    LicenceUrl= "http://opengl.com",
                    ProjectUrl= "https://github.com/NetCoreStack/Hisar",
                    IconUrl= "https://cdn3.iconfinder.com/data/icons/google-suits-1/32/21_g_suit_google_pack_service_image-128.png",
                    RepositoryUrl= "https://github.com/NetCoreStack/Hisar",
                    Tags= "Hisar,Carousel,Slider,Plugin",
                    ReleaseNotes= "<section><h2>Your placeholder text :</h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ad rem redeamus; Sumenda potius quam expetenda. <mark>Maximus dolor, inquit, brevis est.</mark> Duo Reges: constructio interrete.</p><ol><li>Atque haec ita iustitiae propria sunt, ut sint virtutum reliquarum communia.</li><li>Hoc simile tandem est?</li><li>Ad eas enim res ab Epicuro praecepta dantur.</li><li>Ut in voluptate sit, qui epuletur, in dolore, qui torqueatur.</li></ol><pre> 	 Quae quod Aristoni et Pyrrhoni omnino visa sunt pro nihilo, 	 ut inter optime valere et gravissime aegrotare nihil prorsus 	 dicerent interesse, recte iam pridem contra eos desitum est 	 disputari. 	 Contineo me ab exemplis. 	 </pre></section>",
                    Controllers = new List<ComponentControllerDescriptor>()
                    {
                        new ComponentControllerDescriptor()
                        {
                            Inherited = "Controller",
                            Name = "CarouselController",
                            ComponentMethods = new List<ComponentMethodDescriptor>()
                            {
                                new ComponentMethodDescriptor()
                                {
                                    Name = "GetCarousel",
                                    ReturnType = "IActionResult",
                                    MethodParameters = new List<ComponentMethodParameterDescriptor>()
                                    {
                                        new ComponentMethodParameterDescriptor
                                        {
                                            ParameterName = "categoryId",
                                            ParameterType = "long",

                                        }
                                    }
                                }
                            }
                        },
                        new ComponentControllerDescriptor()
                        {
                            Inherited = "Controller",
                            Name = "SampleController",
                            ComponentMethods = new List<ComponentMethodDescriptor>()
                            {
                                new ComponentMethodDescriptor()
                                {
                                    Name = "GetSample",
                                    ReturnType = "IActionResult",
                                    MethodParameters = new List<ComponentMethodParameterDescriptor>()
                                    {
                                        new ComponentMethodParameterDescriptor
                                        {
                                            ParameterName = "name",
                                            ParameterType = "string",
                                        },
                                        new ComponentMethodParameterDescriptor
                                        {
                                            ParameterName = "id",
                                            ParameterType = "long",
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                ,
                new AssemblyDescriptor()
                {
                    PackageId= "ComponentManagementApp",
                    PackageVersion= "1.2.3.4",
                    Authors= "Taha İPEK",
                    Company= "Bilge Adam Bilişim Hiz. Ltd. Şti.",
                    Product= "Component Management",
                    Description= "NetcoreStack Hisar Component Management",
                    Copyright= "Opengl Licence",
                    LicenceUrl= "http://opengl.com",
                    ProjectUrl= "https://github.com/NetCoreStack/Hisar",
                    IconUrl= "https://cdn0.iconfinder.com/data/icons/summer-2/128/Summer_512px-04.png",
                    RepositoryUrl= "https://github.com/NetCoreStack/Hisar",
                    Tags= "Hisar,Component,Management,Plugin",
                    ReleaseNotes= "<section><h2>Your placeholder text :</h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ad rem redeamus; Sumenda potius quam expetenda. <mark>Maximus dolor, inquit, brevis est.</mark> Duo Reges: constructio interrete.</p><ol><li>Atque haec ita iustitiae propria sunt, ut sint virtutum reliquarum communia.</li><li>Hoc simile tandem est?</li><li>Ad eas enim res ab Epicuro praecepta dantur.</li><li>Ut in voluptate sit, qui epuletur, in dolore, qui torqueatur.</li></ol><pre> 	 Quae quod Aristoni et Pyrrhoni omnino visa sunt pro nihilo, 	 ut inter optime valere et gravissime aegrotare nihil prorsus 	 dicerent interesse, recte iam pridem contra eos desitum est 	 disputari. 	 Contineo me ab exemplis. 	 </pre></section>",
                    NeutrelLanguage= "Tuskish,English",
                    Version= "2.0.0.0",
                    FileVersion= "3.0.0.0",
                    Controllers = new List<ComponentControllerDescriptor>()
                    {
                        new ComponentControllerDescriptor()
                        {
                            Inherited = "Controller",
                            Name = "HomeController",
                            ComponentMethods = new List<ComponentMethodDescriptor>()
                            {
                                new ComponentMethodDescriptor()
                                {
                                    Name = "GetAsseblies",
                                    ReturnType = "IActionResult"
                                }
                            }
                        }
                    }
                }
                ,
                new AssemblyDescriptor()
                {
                    PackageId= "GuidelineApp",
                    PackageVersion= "1.2.3.4",
                    Authors= "Gencebay Demir",
                    Company= "Bilge Adam Bilişim Hiz. Ltd. Şti.",
                    Product= "Carousel",
                    Description= "NetcoreStack Hisar Guideline",
                    Controllers = new List<ComponentControllerDescriptor>()
                    {
                        new ComponentControllerDescriptor()
                        {
                            Inherited = "Controller",
                            Name = "GuidelineController",
                            ComponentMethods = new List<ComponentMethodDescriptor>()
                            {
                                new ComponentMethodDescriptor()
                                {
                                    Name = "GetGuideline",
                                    ReturnType = "IActionResult"
                                }
                            }
                        }
                    }
                }
            };
            */

            #endregion

            var assemblyLoader = _componentModelBuilderHelper.GetLoadedAssemblyInformation();
            return Json(assemblyLoader);
        }

        [HttpGet]
        public IActionResult GetA(string a)
        {
            return new JsonResult("");
        }

        [HttpGet]
        public IActionResult GetB(int a, int b)
        {
            return new JsonResult("");
        }

        [HttpPost]
        public IActionResult GetC(ComponentControllerDescriptor componentViewModel)
        {
            return new JsonResult("");
        }
    }
}
