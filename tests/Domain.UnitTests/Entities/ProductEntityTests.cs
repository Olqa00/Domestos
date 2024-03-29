namespace Domestos.Domain.UnitTests.Entities;

using Domestos.Domain.Entities;
using Domestos.Domain.Exceptions;
using Domestos.Domain.Types;
using Shouldly;

[TestClass]
public sealed class ProductEntityTests
{
    [TestMethod]
    public void Constructor_ShouldCreateObject()
    {
        // Arrange
        var productId = new ProductId(Guid.NewGuid());
        var name = "name";

        // Act
        var sut = new ProductEntity(productId, name);

        // Assets
        sut
            .ShouldBeOfType<ProductEntity>()
            .ShouldNotBeNull()
            ;

        sut.Id
            .ShouldBe(productId)
            ;

        sut.Name
            .ShouldBe(name)
            ;
    }

    [TestMethod]
    public void Constructor_ShouldNotCreateObjectWithEmptyName()
    {
        // Arrange
        var productId = new ProductId(Guid.NewGuid());
        var name = string.Empty;

        // Act
        var sut = () => new ProductEntity(productId, name);

        // Assets
        sut
            .ShouldThrow<IncorrectNameException>()
            ;
    }

    [TestMethod]
    public void SetName_ShouldChangeName()
    {
        // Arrange
        var productId = new ProductId(Guid.NewGuid());
        var oldName = "oldName";
        var newName = "newName";
        var sut = new ProductEntity(productId, oldName);

        // Act
        sut.SetName(newName);

        // Assets
        sut.Name
            .ShouldBe(newName)
            ;
    }

    [TestMethod]
    public void SetName_ShouldNotChangeToEmptyName()
    {
        // Arrange
        var productId = new ProductId(Guid.NewGuid());
        var oldName = "oldName";
        var newName = string.Empty;
        var productEntity = new ProductEntity(productId, oldName);

        // Act
        var sut = () => productEntity.SetName(newName);

        // Assets
        sut
            .ShouldThrow<IncorrectNameException>()
            ;
    }
}
