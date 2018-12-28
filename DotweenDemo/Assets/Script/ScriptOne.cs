using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScriptOne : MonoBehaviour {

    /// <summary>
    /// Unity自带的颜色渐变的组件
    /// </summary>
    public Gradient gradient;

	// Use this for initialization
	void Start () {

        #region 移动 选择 缩放
        //移动到某个坐标
        //transform.DOMove(Vector3.one,2f);
        //transform.DOLocalMove(Vector3.one, 2f);

        //跳跃到某个坐标
        //transform.DOJump(Vector3.one,3f,1,1f);

        //三种旋转方式
        //transform.DORotate(new Vector3(0,90f,0),2f);
        //transform.DORotateQuaternion(new Quaternion(0.1f, 0.1f, 0.1f, 0.1f),2f);
        //transform.DOLookAt(Vector3.one, 2f); //朝向某个方向

        //缩放
        //transform.DOScale(Vector3.one*2,2f);
        #endregion

        #region 几个常用的方法
        //Punch系列方法： 实现来回运动
        //第一个参数 punch：需要运动的向量（包含方向 力大小）
        //第二个参数 duration：持续时间
        //第三个参数：震动次数（频率）
        //第四个参数：取值范围0-1   取值最大，往反方向的力越大  
        //transform.DOPunchPosition(new Vector3(0, 1, 0), 2, 2, 0.1f);
        //transform.DOPunchRotation(new Vector3(0, 1, 0), 2, 2, 0.1f);
        //transform.DOPunchScale(new Vector3(0, 1, 0), 2, 2, 0.1f);

        //Shake系列方法：震动(向四面八方震动)   适用于相机的震动效果
        //transform.DOShakePosition(2, Vector3.one, 10, 90);
        //transform.DOShakeRotation(2, Vector3.one, 10, 90);
        //transform.DOShakeScale(2, Vector3.one, 10, 90);

        //Blend系列方法：混合作用 （增量动画） 
        //如果单纯的调用两个DoMove，GameObject会遵循最下面的那个DoMove方法进行移动。
        //调用Blend方法可以对多个坐标进行混合计算，得到GameObject最终需要移动的坐标。
        //transform.DOBlendableMoveBy(Vector3.one,2f);
        //transform.DOBlendableMoveBy(-Vector3.one*2, 2f);
        //transform.DOBlendableRotateBy();
        //transform.DOBlendableScaleBy();
        //transform.DOBlendablePunchRotation();
        #endregion

        #region Material
        Material material = GetComponent<MeshRenderer>().material;
        //1.改变材质颜色 （前提Shader上有main color属性_Color，也就是说明修改material上的color实际上是修改的shader上面的main color）
        //如果shader上面没有main color，可通过查找shader上面的相关color属性（假设是_TintColor），通过添加其名称的方式来修改其color值
        //material.DOColor(Color.red,2);
        //material.DOColor(Color.green,"_TintColor",2);
        //2.改变材质透明度（Alpha值）
        //material.DOColor(Color.clear, 2);//设置RGBA为(0,0,0,0)
        material.DOFade(0, 2);//直接修改Aplha值   注：这里需要透明材质的Image
                              //3.材质颜色渐变  
                              //material.DOGradientColor(gradient,2f);
                              //4.材质Offset改变 （注意：材质的改变是瞬间的，不能有渐变的效果，不然会产生很奇怪的感觉）
                              //material.DOOffset(Vector3.one,2);
                              //5.改变Shader属性值（改变四维向量的属性）
                              //material.DOVector(Color.clear, "_Color", 2);
                              //6.颜色混合
                              //material.DOBlendableColor(Color.green, 2);
                              //material.DOBlendableColor(Color.red, 2);
        #endregion

        #region Camera
        //Camera camera = GetComponent<Camera>();
        //1.改变相机的宽高比  
        //第一个参数：宽/高
        //camera.DOAspect(1f,2);
        //2.改变颜色
        //camera.DOColor(Color.green,2);
        //3.修改相机的近切面和远切面
        //camera.DONearClipPlane();
        //camera.DOFarClipPlane();
        //4.相机的“视域” 简称FOV  实现枪械倍镜（放大缩小）的效果
        //camera.DOFieldOfView(1,2);//修改透视Camera的“视域”
        //camera.DOOrthoSize(1,2); //修改正交Camera的“视域”
        //5.修改Camera显示的屏幕大小（屏幕占比），实现分屏效果
        //camera.DOPixelRect(new Rect(0,0,540,1080),2);//通过直接修改像素
        //camera.DORect(new Rect(0, 0, 0.5f, 0.5f), 2);//通过百分比来改变Camera的屏幕占比,实际上是修改Viewport Rect值
        //6.Camer震动效果
        //camera.DOShakePosition(2, Vector3.one, 10, 90);
        #endregion

        #region Text
        //Text text = GetComponent<Text>();
        //text.DOColor();//改变颜色
        //text.DOFade();//改变Alpha
        //text.DOBlendableColor();//颜色混合
        //text.DOText("hello world",5f).SetEase(Ease.Linear);//匀速实现字一个个出现的效果
        #endregion

        #region 队列
        //两种常用的初始化方法，建议使用第一种
        Sequence sequence = DOTween.Sequence();
        //DOTween.Sequence().Append();
        //1.给队列添加方法
        //添加到sequence的方法会依次执行，并且可以使用AppendInterval方法来延迟执行其后的方法
        //sequence.Append(transform.DOMove(Vector3.one,2));   
        //sequence.AppendInterval(1); //延时1秒
        //sequence.Append(transform.DOMove(new Vector3(2,2,2), 2));
        //2.给队列插入方法  注意：参数atPosition实际上指的是时间
        //在某个时间点插入该方法，要注意这个时间点在当前队里中是否有方法，否则会覆盖其他的方法
        //sequence.Insert(0,transform.DOMove(Vector3.one, 2));
        //3.在队列加入方法，可以通过Insert或Join加入相关方法
        //sequence.Append(transform.DOMove(Vector3.one, 2));
        //sequence.Join(transform.DOScale(Vector3.one*2,2));  //这个方法会和上面的方法同时执行
        //sequence.AppendInterval(1); //延时1秒
        //sequence.Append(transform.DOMove(new Vector3(2, 2, 2), 2));
        //4.在队列之前添加方法   预添加的方法里面后添加的先执行
        // 比如下面fun2先执行  fun1后执行
        //sequence.Prepend(transform.DOMove(Vector3.one, 2));//fun1
        //sequence.Prepend(transform.DOMove(Vector3.one*2, 2));//fun2
        //5.回调函数  在队列指定的时间进行函数的调用   预添加，队列追加，队列插入 三种模式都有回调方法
        //sequence.InsertCallback(5, InsertCallFunction);
        //sequence.AppendCallback(InsertCallFunction);
        //sequence.PrependCallback(InsertCallFunction);
        #endregion

    }

    public void InsertCallFunction()
    {
        Debug.Log("InsertCallFunction");
    }

}
