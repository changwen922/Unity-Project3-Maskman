using UnityEngine;

public class audio : MonoBehaviour
{
	// 音データの再生装置を格納する変数
	private AudioSource Audio;

	// 音データを格納する変数（Inspectorタブからも値を変更できるようにする）
	[SerializeField]
	private AudioClip sound;

	// Start is called before the first frame update
	void Start()
    {
		// ゲームスタート時にAudioSource（音再生装置）のコンポーネントを加える
		Audio = gameObject.AddComponent<AudioSource>();

	}

	/// <summary>
	/// 衝突した時
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		// 衝突した相手にPlayerタグが付いているとき
		if (collision.gameObject.tag == "Player")
		{
			// 音（sound）を一度だけ（PlayOneShot）再生する
			Audio.PlayOneShot(sound);
		}
	}
}
