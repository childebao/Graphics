using System;
using UnityEngine;
using UnityEngine.Experimental.VFX;

namespace UnityEditor.Experimental.VFX
{
    public class VFXBlockSizeConstantSquare : VFXBlockType
    {
        public VFXBlockSizeConstantSquare()
        {
            Name = "Set Size Constant (Square)";
            Icon = "Size";
            Category = "Size";

            Add(new VFXProperty(new VFXFloatType(0.1f),"Size"));

            Add(new VFXAttribute(CommonAttrib.Size, true));

            Source = @"
size = float2(Size,Size);";
        }
    }

    public class VFXBlockSizeConstantRectangle : VFXBlockType
    {
        public VFXBlockSizeConstantRectangle()
        {
            Name = "Set Size Constant (Rectangle)";
            Icon = "Size";
            Category = "Size";

            Add(new VFXProperty(new VFXFloat2Type(new Vector2(0.05f,0.1f)),"Size"));

            Add(new VFXAttribute(CommonAttrib.Size, true));

            Source = @"
size = Size;";
        }
    }

    public class VFXBlockSizeRandomSquare : VFXBlockType
    {
        public VFXBlockSizeRandomSquare()
        {
            Name = "Set Size Random (Square)";
            Icon = "Size";
            Category = "Size";

            Add(new VFXProperty(new VFXFloatType(0.1f),"MinSize"));
            Add(new VFXProperty(new VFXFloatType(0.1f),"MaxSize"));

            Add(new VFXAttribute(CommonAttrib.Size, true));

            Source = @"
float s = lerp(MinSize,MaxSize,RAND);
size = float2(s,s);";
        }
    }

    public class VFXBlockApplyRandomScaleUniform : VFXBlockType
    {
        public VFXBlockApplyRandomScaleUniform()
        {
            Name = "Apply Random Scale (Uniform)";
            Icon = "Size";
            Category = "Size";

            Add(new VFXProperty(new VFXFloatType(0.1f),"MinSize"));
            Add(new VFXProperty(new VFXFloatType(0.1f),"MaxSize"));

            Add(new VFXAttribute(CommonAttrib.Size, true));

            Source = @"
float s = lerp(MinSize,MaxSize,RAND);
size = float2(s,s);";
        }
    }

    public class VFXBlockApplyScaleRatio : VFXBlockType
    {
        public VFXBlockApplyScaleRatio()
        {
            Name = "Apply Scale Ratio";
            Icon = "Size";
            Category = "Size";

            Add(new VFXProperty(new VFXFloatType(0.5f),"Ratio"));

            Add(new VFXAttribute(CommonAttrib.Size, true));

            Source = @"
size *= float2(1.0,Ratio);";
        }
    }

    public class VFXBlockApplyScaleRatioFromVelocity : VFXBlockType
    {
        public VFXBlockApplyScaleRatioFromVelocity()
        {
            Name = "Scale Height from Speed (Constant)";
            Icon = "Size";
            Category = "Size";

            Add(new VFXProperty(new VFXFloatType(0.5f),"Multiplier"));

            Add(new VFXAttribute(CommonAttrib.Size, true));
            Add(new VFXAttribute(CommonAttrib.Velocity, false));

            Source = @"
size.y = length(velocity) * Multiplier;";
        }
    }

    public class VFXBlockApplyScaleRatioFromVelocityCurve : VFXBlockType
    {
        public VFXBlockApplyScaleRatioFromVelocityCurve()
        {
            Name = "Scale Height from Speed (Curve)";
            Icon = "Size";
            Category = "Size";

            Add(new VFXProperty(new VFXCurveType(),"Curve"));

            Add(new VFXAttribute(CommonAttrib.Size, true));
            Add(new VFXAttribute(CommonAttrib.Velocity, false));

            Source = @"
size.y = SAMPLE(Curve, length(velocity));";
        }
    }

    public class VFXBlockSizeOverLifeCurve : VFXBlockType
    {
        public VFXBlockSizeOverLifeCurve()
        {
            Name = "Scale over Life (Curve)";
            Icon = "Size";
            Category = "Size";

            Add(VFXProperty.Create<VFXCurveType>("Curve"));
            Add(new VFXProperty(new VFXFloatType(0.1f),"MaxSize"));

            Add(new VFXAttribute(CommonAttrib.Size, true));
            Add(new VFXAttribute(CommonAttrib.Age, false));
            Add(new VFXAttribute(CommonAttrib.Lifetime, false));

            Source = @"
float ratio = saturate(age/lifetime);
float s = SAMPLE(Curve, ratio);
size = float2(s,s);";
        }
    }

    public class VFXBlockSizeOverAgeCurve : VFXBlockType
    {
        public VFXBlockSizeOverAgeCurve()
        {
            Name = "Scale over Age (Curve)";
            Icon = "Size";
            Category = "Size";

            Add(VFXProperty.Create<VFXCurveType>("Curve"));
            Add(new VFXProperty(new VFXFloatType(0.1f),"MaxSize"));

            Add(new VFXAttribute(CommonAttrib.Size, true));
            Add(new VFXAttribute(CommonAttrib.Age, false));

            Source = @"
float s = SAMPLE(Curve, age);
size = float2(s,s);";
        }
    }
}
