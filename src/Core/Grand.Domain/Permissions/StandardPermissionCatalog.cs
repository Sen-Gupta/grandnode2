﻿namespace Grand.Domain.Permissions;

public static partial class StandardPermission
{
    public static readonly Permission ManageProducts = new() {
        Name = "Manage Products",
        SystemName = PermissionSystemName.Products,
        Area = "Admin area",
        Category = CategoryCatalog,
        Actions = new List<string> {
            PermissionActionName.List, PermissionActionName.Create, PermissionActionName.Edit,
            PermissionActionName.Preview, PermissionActionName.Delete, PermissionActionName.Export,
            PermissionActionName.Import
        }
    };

    public static readonly Permission ManageCategories = new() {
        Name = "Manage Categories",
        SystemName = PermissionSystemName.Categories,
        Area = "Admin area",
        Category = CategoryCatalog,
        Actions = new List<string> {
            PermissionActionName.List, PermissionActionName.Create, PermissionActionName.Edit,
            PermissionActionName.Preview, PermissionActionName.Delete, PermissionActionName.Export,
            PermissionActionName.Import
        }
    };

    public static readonly Permission ManageBrands = new() {
        Name = "Manage Brands",
        SystemName = PermissionSystemName.Brands,
        Area = "Admin area",
        Category = CategoryCatalog,
        Actions = new List<string> {
            PermissionActionName.List, PermissionActionName.Create, PermissionActionName.Edit,
            PermissionActionName.Preview, PermissionActionName.Delete, PermissionActionName.Export,
            PermissionActionName.Import
        }
    };

    public static readonly Permission ManageCollections = new() {
        Name = "Manage Collections",
        SystemName = PermissionSystemName.Collections,
        Area = "Admin area",
        Category = CategoryCatalog,
        Actions = new List<string> {
            PermissionActionName.List, PermissionActionName.Create, PermissionActionName.Edit,
            PermissionActionName.Preview, PermissionActionName.Delete, PermissionActionName.Export,
            PermissionActionName.Import
        }
    };

    public static readonly Permission ManageProductReviews = new() {
        Name = "Manage Product Reviews",
        SystemName = PermissionSystemName.ProductReviews,
        Area = "Admin area",
        Category = CategoryCatalog,
        Actions = new List<string> {
            PermissionActionName.List, PermissionActionName.Edit, PermissionActionName.Preview,
            PermissionActionName.Delete
        }
    };

    public static readonly Permission ManageProductTags = new() {
        Name = "Manage Product Tags",
        SystemName = PermissionSystemName.ProductTags,
        Area = "Admin area",
        Category = CategoryCatalog,
        Actions = new List<string> {
            PermissionActionName.List, PermissionActionName.Edit, PermissionActionName.Preview,
            PermissionActionName.Delete
        }
    };

    public static readonly Permission ManageProductAttributes = new() {
        Name = "Manage Product Attributes",
        SystemName = PermissionSystemName.ProductAttributes,
        Area = "Admin area",
        Category = CategoryCatalog,
        Actions = new List<string> {
            PermissionActionName.List, PermissionActionName.Create, PermissionActionName.Edit,
            PermissionActionName.Preview, PermissionActionName.Delete
        }
    };

    public static readonly Permission ManageSpecificationAttributes = new() {
        Name = "Manage Specification Attributes",
        SystemName = PermissionSystemName.SpecificationAttributes,
        Area = "Admin area",
        Category = CategoryCatalog,
        Actions = new List<string> {
            PermissionActionName.List, PermissionActionName.Create, PermissionActionName.Edit,
            PermissionActionName.Preview, PermissionActionName.Delete
        }
    };

    public static readonly Permission ManageContactAttribute = new() {
        Name = "Manage Contact Attribute",
        SystemName = PermissionSystemName.ContactAttributes,
        Area = "Admin area",
        Category = CategoryCatalog,
        Actions = new List<string> {
            PermissionActionName.List, PermissionActionName.Create, PermissionActionName.Edit,
            PermissionActionName.Preview, PermissionActionName.Delete
        }
    };

    private static string CategoryCatalog => "Catalog";
}