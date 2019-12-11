﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of IrradiationDose.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class IrradiationDoseTestsBase
    {
        protected abstract double GrayInOneGray { get; }
        protected abstract double MilligrayInOneGray { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double GrayTolerance { get { return 1e-5; } }
        protected virtual double MilligrayTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new IrradiationDose((double)0.0, IrradiationDoseUnit.Undefined));
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new IrradiationDose(double.PositiveInfinity, IrradiationDoseUnit.Gray));
            Assert.Throws<ArgumentException>(() => new IrradiationDose(double.NegativeInfinity, IrradiationDoseUnit.Gray));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new IrradiationDose(double.NaN, IrradiationDoseUnit.Gray));
        }

        [Fact]
        public void GrayToIrradiationDoseUnits()
        {
            IrradiationDose gray = IrradiationDose.FromGray(1);
            AssertEx.EqualTolerance(GrayInOneGray, gray.Gray, GrayTolerance);
            AssertEx.EqualTolerance(MilligrayInOneGray, gray.Milligray, MilligrayTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, IrradiationDose.From(1, IrradiationDoseUnit.Gray).Gray, GrayTolerance);
            AssertEx.EqualTolerance(1, IrradiationDose.From(1, IrradiationDoseUnit.Milligray).Milligray, MilligrayTolerance);
        }

        [Fact]
        public void FromGray_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => IrradiationDose.FromGray(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => IrradiationDose.FromGray(double.NegativeInfinity));
        }

        [Fact]
        public void FromGray_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => IrradiationDose.FromGray(double.NaN));
        }

        [Fact]
        public void As()
        {
            var gray = IrradiationDose.FromGray(1);
            AssertEx.EqualTolerance(GrayInOneGray, gray.As(IrradiationDoseUnit.Gray), GrayTolerance);
            AssertEx.EqualTolerance(MilligrayInOneGray, gray.As(IrradiationDoseUnit.Milligray), MilligrayTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var gray = IrradiationDose.FromGray(1);

            var grayQuantity = gray.ToUnit(IrradiationDoseUnit.Gray);
            AssertEx.EqualTolerance(GrayInOneGray, (double)grayQuantity.Value, GrayTolerance);
            Assert.Equal(IrradiationDoseUnit.Gray, grayQuantity.Unit);

            var milligrayQuantity = gray.ToUnit(IrradiationDoseUnit.Milligray);
            AssertEx.EqualTolerance(MilligrayInOneGray, (double)milligrayQuantity.Value, MilligrayTolerance);
            Assert.Equal(IrradiationDoseUnit.Milligray, milligrayQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            IrradiationDose gray = IrradiationDose.FromGray(1);
            AssertEx.EqualTolerance(1, IrradiationDose.FromGray(gray.Gray).Gray, GrayTolerance);
            AssertEx.EqualTolerance(1, IrradiationDose.FromMilligray(gray.Milligray).Gray, MilligrayTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            IrradiationDose v = IrradiationDose.FromGray(1);
            AssertEx.EqualTolerance(-1, -v.Gray, GrayTolerance);
            AssertEx.EqualTolerance(2, (IrradiationDose.FromGray(3)-v).Gray, GrayTolerance);
            AssertEx.EqualTolerance(2, (v + v).Gray, GrayTolerance);
            AssertEx.EqualTolerance(10, (v*10).Gray, GrayTolerance);
            AssertEx.EqualTolerance(10, (10*v).Gray, GrayTolerance);
            AssertEx.EqualTolerance(2, (IrradiationDose.FromGray(10)/5).Gray, GrayTolerance);
            AssertEx.EqualTolerance(2, IrradiationDose.FromGray(10)/IrradiationDose.FromGray(5), GrayTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            IrradiationDose oneGray = IrradiationDose.FromGray(1);
            IrradiationDose twoGray = IrradiationDose.FromGray(2);

            Assert.True(oneGray < twoGray);
            Assert.True(oneGray <= twoGray);
            Assert.True(twoGray > oneGray);
            Assert.True(twoGray >= oneGray);

            Assert.False(oneGray > twoGray);
            Assert.False(oneGray >= twoGray);
            Assert.False(twoGray < oneGray);
            Assert.False(twoGray <= oneGray);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            IrradiationDose gray = IrradiationDose.FromGray(1);
            Assert.Equal(0, gray.CompareTo(gray));
            Assert.True(gray.CompareTo(IrradiationDose.Zero) > 0);
            Assert.True(IrradiationDose.Zero.CompareTo(gray) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            IrradiationDose gray = IrradiationDose.FromGray(1);
            Assert.Throws<ArgumentException>(() => gray.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            IrradiationDose gray = IrradiationDose.FromGray(1);
            Assert.Throws<ArgumentNullException>(() => gray.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = IrradiationDose.FromGray(1);
            var b = IrradiationDose.FromGray(2);

 // ReSharper disable EqualExpressionComparison

            Assert.True(a == a);
            Assert.False(a != a);

            Assert.True(a != b);
            Assert.False(a == b);

            Assert.False(a == null);
            Assert.False(null == a);

// ReSharper restore EqualExpressionComparison
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            var a = IrradiationDose.FromGray(1);
            var b = IrradiationDose.FromGray(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = IrradiationDose.FromGray(1);
            Assert.True(v.Equals(IrradiationDose.FromGray(1), GrayTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(IrradiationDose.Zero, GrayTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            IrradiationDose gray = IrradiationDose.FromGray(1);
            Assert.False(gray.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            IrradiationDose gray = IrradiationDose.FromGray(1);
            Assert.False(gray.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(IrradiationDoseUnit.Undefined, IrradiationDose.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(IrradiationDoseUnit)).Cast<IrradiationDoseUnit>();
            foreach(var unit in units)
            {
                if(unit == IrradiationDoseUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(IrradiationDose.BaseDimensions is null);
        }
    }
}