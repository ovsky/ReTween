
# 📦 ReTween - Fastest Unity and C# Tweening Solution 

## 📒 ReTween
ReTween is blazing fast, zero-garbage, modular, really simple and effective Tweening System for Unity.


## 📖 QuickStart
### ReTween:

So, let's use the Tween!

#### Usage:
Tween position and color:

```csharp
Tween.Position(transform, Vector3.right);
Tween.Color(someImage, Color.blue).SetDelay(0.5f);
```

So, it's pretty easy!

#### Extended Usage:

Tween position and color with functions, methods and custom delays, durations and easings:
```csharp
Tween.Position(transform, new Vecor3(0, 5, 0), delay, duration);
Tween.Position(transform, position);
Tween.Position(transform, () => FindTarget());

Tween.Color(image, Color.blue, delay, 1.0f, Ease.InOut);
Tween.Color(image, Color.blue).SetDelay(0.5f).SetEase(EaseType.Linear);
```

#### Next:
Tween scale using custom chain of things called in sequence, one after one, with waiting:

```csharp
Tween.Scale(transform, Vector3.one * 3f, 1f, 0f, anotherEase)
    .Next(Tween.Scale(transform, Vector3.one * 4f))
    .Next(Tween.Wait(3f))
    .Next(Tween.Scale(transform, Vector3.one * 2f, 1f, 0f, anotherEase))
        .SetDelay(5f));
```

#### Async:
Tweening fully asynchronous, where you can yield custom async function by them, and use it as enumerables:

```csharp
yield return Tween.Scale(transform, Vector3.zero, 1f, 0f, scaleEase);
yield return Tween.Position(transform, Vector3.right * 3f, 1f, 0f, anotherEase);
yield return Tween.Wait(2f);
yield return Tween.Scale(transform, Vector3.one * 3f, 1f, 0f, anotherEase);
```

#### Break:
Tweening with custom cause of break, based on boolean expression and object existence check:
 
**Break Point** @ set if you want to finish tween on reaching some function:

```csharp
Tween.Color(someImage, Color.blue)
    .SetBreakPoint(() => colorLoopActive && colorTarget == 1);

Tween.Position(transform, targetPosition)
    .SetBreakPoint(() => IsTweenActive());
```

**Break Object** @ set if you want to finish tween on destroy of target object:

```csharp
Tween.Color(someImage, Color.blue)
    .SetBreakObject(parentObject);
```

---

### 🗂️ ReExtensions:
ReTween supports custom  [extensions, like predefined: 

```csharp 
ReTween.Next()
```
Where you can define next custom Action and TweenAction.  

`ReTween.SetEase()` - where you can define easing mode.

`ReTween.SetDelay()` - where you can define delay.

`SetAction`, `SetDuration`, `SetStartTime`, `SetBreakPoint`, `SetBreakObject` - and more.

---

### 📚 ReModules:

You can create new ReModule by writing new script in ReTween/Modules that will assign new method by `Tween.Add()` and describe new `Action<float>`, where the `float` is easing time, from 0 to 1.

To follow the ReTween guidelines, you can write your new class as *partial* of the RwTween *(by Tween.YourModule())*.

Example: 
If we want to add a Color Lerp module for UI.Image, we need to write simple instruction:

```csharp
public static void Color(Image image, Color target)
{
    Tween.Add(new TweenAction((float time) => image.color = UnityEngine.Color.LerpUnclamped(image.color, target, time)));
}
```

Obviously, you can create more complex Tweens. Basic `TweenAction` is built with pre-implemented values, like: `duration`, `delay`, `easing`, like:

```csharp
public static void Color(Image image, Color target, float duration = 1f, float delay = 0f, Ease ease = null)
{
    Tween.Add(new TweenAction((float time) => image.color = UnityEngine.Color.LerpUnclamped(image.color, target, time), duration, delay, ease));
}
```

Now to tween the UI Image color, you can write in your code:
```csharp
Tween.Color(someImage, Color.blue, 0.5f, 2f);
```

---

### 📘 Ease / Easing:

#### How easing works?

Easings are some sort of simple curves, that helps to visualise and evaluate smooth and juicy, animations. You can use some of the predefined curves or create own.

Easing Examples:

![Easing Preview Animation](https://i.ibb.co/4YmJ578/tween-animation-x2-waifu2x-900x465-opt-1-1-1.gif)

--- 

#### Technical:

*Ease* is fully compatible and swapable with Unity AnimationCurves - which with you may be already familiar.
In every field you have used AnimationCurve, you can use Ease as the replacement, without changing the implementation. 
The most important difference is that Eases has many predefined, basic values - a bank of custom definition - they are completely garbage-free and made with optimisation in-mind. 

### ⏩ Supported high-performace Ease Calculations:

**ReTween** provides implementation of 30+ high-performance math patterns for easing types:

```csharp  
    Linear = 0,
    QuadIn = 1,
    QuadOut = 2,
    QuadInOut = 3,
    CubicIn = 4,
    CubicOut = 5,
    CubicInOut = 6,
    QuartIn = 7,
    QuartOut = 8,
    QuartInOut = 9,
    QuintIn = 10,
    QuintOut = 11,
    QuintInOut = 12,
    BounceIn = 13,
    BounceOut = 14,
    BounceInOut = 15,
    ElasticIn = 16,
    ElasticOut = 17,
    ElasticInOut = 18,
    SlowElasticIn  =  19,
    CircularIn  =  20,
    CircularOut  =  21,
    CircularInOut  =  22,
    SinusIn  =  23,
    SinusOut  =  24,
    SinusInOut  =  25,
    ExponentialIn  =  26,
    ExponentialOut  =  27,
    ExponentialInOut  =  28,|
    BackwardIn  =  29,
    BackwardOut  =  30,
    BackwardInOut  =  31,
    BackwardInOutHalf  =  32,
```
### In-Editor Ease:

#### Declaration:

You can cuse predefined or custom Ease Tweening Curve, and expose it in editor, by declaring:

```csharp
[SerializeField] Ease customEase;
```

#### Usage:
Now you have ecess to exposed Ease definition, which you can use in any Tween:

**Ease Drawer** allows you to use - preview and selection:

![Easing Preview Anixmation](https://i.ibb.co/8rtVP28/Screenshot-2023-10-18-133954-waifu2x-4xxx.png)

If you select the last type - "Custom", you can declare your own Ease Curve, which can be used as Ease everywhere:

![Easing Preview Animation](https://i.ibb.co/mty0Tv0/Screenshot-2023-10-18-133954-waifu2x-4x-png.png)

For example, by:
 ```csharp
Tween.Scale(transform, Vector3.zero).SetEase(myEase);
```

## 📗 API Reference

#### The structure of basic *TweenAction*:

| TweenAction | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `startTime` | `float` | TweenAction start time. *[auto assigned][read-only]* |
| `action` | `Action<float>` | Main action, that receives the float value as lerp time. |
| `delay` | `float` | Time to start invoking TweenAction |
| `duration` | `float` | Duration of tweening process. |
| `breakPoint` | `Func<bool>` | Function that should be meet to break tween. |
| `breakObject` | `GameObject` | Function that should be destroyed to break tween. |

#### *Ease* base construction operators:

```csharp
EaseType, AnimationCurve, Ease
```

#### *Ease* public static methods:
```csharp
Ease SetEaseName<string>(value)
Ease GetCustom<string>(value)
Ease SetCustom<string>(value)
```


## 📝 License:

License: 
Copyright (c) 2023 - Przemysław Orłowski

MIT License

https://raw.githubusercontent.com/ovsky/ReTween/main/Assets/Lab7/LICENSE.txt
