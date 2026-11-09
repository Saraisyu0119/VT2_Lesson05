using Unity.VisualScripting;
using UnityEngine;

public class CalcVector : MonoBehaviour
{
	public enum CalcType
	{
		Additive,
		Multiply,
		Subtruct,
		DotProduct,
		CrossProduct,
	}

	public CalcType calcType;

	public float scale = 1.0f;

	public Vector3 A;
	public Vector3 B;

	public Vector3 Result;
	public float ResultDot;

	private void Start()
	{
		
	}

	private void Update()
	{
		Result = Vector3.zero;

		switch(calcType)
		{
			case CalcType.Additive:
				Result = Additive(A, B);
				break;

			case CalcType.Subtruct:
				Result = Subtruct(A, B);
				break;

			case CalcType.Multiply:
				Result = Multiply(A, B);
				break;

			case CalcType.DotProduct:
				ResultDot = DotProduct(A, B);
				break;

			case CalcType.CrossProduct:
				Result = CrossProduct(A, B);
				break;
		}
	}

	//! AとBのベクトルを合成したベクトルを返す
	public Vector3 Additive(Vector3 A, Vector3 B)
	{
		Vector3 result = A + B;

		Vector3 scaledA = A * scale;
		Vector3 scaledB = B * scale;
		Vector3 scaledResult = scaledA + scaledB;

		//! ベクトルを可視化
		//? Debug.DrawRay(始点, 方向, 色, 描画時間, 深度設定);
		Debug.DrawRay(Vector3.zero, scaledA, Color.red, 0, false);
		Debug.DrawRay(Vector3.zero, scaledB, Color.blue, 0, false);
		Debug.DrawRay(scaledB, scaledA, Color.red, 0, false);
		Debug.DrawRay(scaledA, scaledB, Color.blue, 0, false);
		Debug.DrawRay(Vector3.zero, scaledResult, Color.green, 0, false);

		return result;
	}

	//! AとBのベクトルを減算したベクトルを返す
	public Vector3 Subtruct(Vector3 A, Vector3 B)
	{
		Vector3 result = A - B;

		Vector3 scaledA = A * scale;
		Vector3 scaledB = B * scale;
		Vector3 scaledResult = scaledA - scaledB;

		//! ベクトルを可視化
		//? Debug.DrawRay(始点, 方向, 色, 描画時間, 深度設定);
		Debug.DrawRay(Vector3.zero, scaledA, Color.red, 0, false);
		Debug.DrawRay(Vector3.zero, scaledB, Color.blue, 0, false);
		Debug.DrawRay(scaledA, -scaledB, Color.blue, 0, false);
		Debug.DrawRay(Vector3.zero, scaledResult, Color.green, 0, false);

		return result;
	}

	//! それぞれの要素ごとの掛け算をする
	public Vector3 Multiply(Vector3 A, Vector3 B)
	{
		// Vector3.Scale(A, B)でも同じことができる
		Vector3 result;
		result.x = A.x * B.x;
		result.y = A.y * B.y;
		result.z = A.z * B.z;

		Vector3 scaledA = A * scale;
		Vector3 scaledB = B * scale;
		Vector3 scaledResult;
		scaledResult.x = scaledA.x * scaledB.x;
		scaledResult.y = scaledA.y * scaledB.y;
		scaledResult.z = scaledA.z * scaledB.z;

		Debug.DrawRay(Vector3.zero, scaledA, Color.red, 0, false);
		Debug.DrawRay(Vector3.zero, scaledB, Color.blue, 0, false);
		Debug.DrawRay(Vector3.zero, scaledResult, Color.green, 0, false);

		return result;
	}

	//! AとBのベクトルの内積を返す（内積は）
	//? 内積とは二つのベクトルの大きさと角度から計算される値で、二つのベクトルがどれだけ同じ方向を向いているかを示す指標です。
	//? 公式
	//? 　幾何学 : A・B = |A| * |B| * cosθ（θは2つのベクトルのなす角）
	//? 　代数   : A・B = Ax * Bx + Ay * By + Az * Bz
	//? 数値の意味
	//? 　正の値（> 0）：2つのベクトルが同じ方向を向いている（0° ? θ < 90°）
	//? 　ゼロ（= 0）：2つのベクトルが直交（垂直）している（θ = 90°）
	//? 　負の値（< 0）：2つのベクトルが逆方向を向いている（90° < θ ? 180°）
	float DotProduct(Vector3 A, Vector3 B)
	{
		// Vector3.Dot(A, B)でも計算可能
		float result = (A.x * B.x) + (A.y * B.y) + (A.z * B.z);

		Vector3 scaledA = A * scale;
		Vector3 scaledB = B * scale;
		float scaledResult = (scaledA.x * scaledB.x) + (scaledA.y * scaledB.y) + (scaledA.z * scaledB.z);

		//! ベクトルを可視化
		//? Debug.DrawRay(始点, 方向, 色, 描画時間, 深度設定);
		Debug.DrawRay(Vector3.zero, scaledA, Color.red, 0, false);
		Debug.DrawRay(Vector3.zero, scaledB, Color.blue, 0, false);
		Debug.DrawRay(Vector3.zero, new Vector3(scaledResult, 0, 0), Color.green, 0, false);
		return result;
	}

	//! AとBの外積を返す
	//? 外積とは
	//? 公式
	//? 　幾何学：A・B = |A| * |B| * sinθ（θは2つのベクトルのなす角）
	Vector3 CrossProduct(Vector3 A, Vector3 B)
	{
		Vector3 result;
		result.x = (A.y * B.z) - (A.z * B.y);
		result.y = (A.z * B.x) - (A.x * B.z);
		result.z = (A.x * B.y) - (A.y * B.x);

		Vector3 scaledA = A * scale;
		Vector3 scaledB = B * scale;

		Vector3 scaledResult;
		scaledResult.x = (A.y * B.z) - (A.z * B.y);
		scaledResult.y = (A.z * B.x) - (A.x * B.z);
		scaledResult.z = (A.x * B.y) - (A.y * B.x);

		//! ベクトルを可視化
		//? Debug.DrawRay(始点, 方向, 色, 描画時間, 深度設定);
		Debug.DrawRay(Vector3.zero, scaledA, Color.red, 0, false);
		Debug.DrawRay(Vector3.zero, scaledB, Color.blue, 0, false);
		Debug.DrawRay(Vector3.zero, scaledResult, Color.green, 0, false);

		return result;
	}
}
