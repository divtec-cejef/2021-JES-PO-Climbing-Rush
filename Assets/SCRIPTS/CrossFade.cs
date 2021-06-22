using UnityEngine;
using System.Collections;

public class CrossFade : MonoBehaviour
{
    private Texture    _newTexture;
    private Vector2    _newOffset;
    private Vector2    _newTiling;

    public Texture textureCiel;
  
    public  float    BlendSpeed = 3.0f;
  
    private bool    _trigger = false;
    private float    _fader = 0f;
  
     
    void Start ()
    {
        GetComponent<Renderer>().material.SetFloat(12,3f);
        GetComponent<Renderer>().material.SetFloat(name, 3f);
        this.GetComponent<Renderer>().material.SetFloat( name, 0f );
    }
  // comm pour commit
    void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _fader += Time.deltaTime * BlendSpeed;
      
            this.GetComponent<Renderer>().material.SetFloat( name, _fader );
      
            if ( _fader >= 1.0f )
            {
                _trigger = false;
                _fader = 0f;
        
                GetComponent<Renderer>().material.SetTexture ("_MainTex", _newTexture );
                GetComponent<Renderer>().material.SetTextureOffset ( "_MainTex", _newOffset );
                GetComponent<Renderer>().material.SetTextureScale ( "_MainTex", _newTiling );
                GetComponent<Renderer>().material.SetFloat( "_Blend", 0f );
            }
            else
            {
                CrossFadeTo(_newTexture, _newOffset, _newTiling);
            }
            
            
            if (Input.GetKey(KeyCode.Space))
            {
                CrossFadeTo(textureCiel,_newOffset,_newTiling);
            }
        }
    }
  
    public void CrossFadeTo( Texture curTexture, Vector2 offset, Vector2 tiling )
    {
        _newOffset = offset;
        _newTiling = tiling;
        _newTexture = curTexture;
        GetComponent<Renderer>().material.SetTexture( "_Texture2", curTexture );
        GetComponent<Renderer>().material.SetTextureOffset ( "_Texture2", _newOffset );
        GetComponent<Renderer>().material.SetTextureScale ( "_Texture2", _newTiling );
        _trigger = true;
    }
}
