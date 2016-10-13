using UnityEngine;
using System.Collections;
using System;

public class Generalization : MonoBehaviour {

    public abstract class BaseClass
    {
        #region BaseProperties
        private float speed;
        protected float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private float turn;

        protected float Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        private Vector3 transform;
        protected Vector3 ChildTransform
        {
            get { return transform; }
            set { transform = value; }
        }

        private Vector3 rotation;

        protected Vector3 ChildRotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        private MeshFilter mMeshFilter;
        protected MeshFilter MyMeshFilter
        {
            get { return mMeshFilter; }
            set { mMeshFilter = value; }
        }

        private MeshRenderer mRenderer;
        protected MeshRenderer MyMeshRenderer
        {
            get { return mRenderer; }
            set { mRenderer = value; }
        }

        private Material mMaterial;
        protected Material MyMaterial
        {
            get { return mMaterial; }
            set { mMaterial = value; }
        }

        private Mesh mMesh;
        protected Mesh MyMesh
        {
            get { return mMesh; }
            set { mMesh = value; }
        }
        #endregion

        #region BaseMethods
        public abstract void Initialize(Mesh mesh, Material material);
        public abstract void MoveForward(float spd, float trn);
        public abstract void ChildUpdate();

        public virtual void Speak()
        {
            Debug.Log("base hello");
        }
        #endregion
    }

    public partial class ChildA : BaseClass
    {
        #region GhildA_propherties
        protected GameObject me;
        #endregion

        public override void Initialize(Mesh mesh, Material material)
        {
            this.MyMesh = mesh;
            this.MyMaterial = material;

            me = new GameObject(this.ToString());
            MyMeshFilter = me.AddComponent<MeshFilter>();
            MyMeshFilter.mesh = this.MyMesh;
            MyMeshRenderer = me.AddComponent<MeshRenderer>();
            MyMeshRenderer.material = this.MyMaterial;

            //throw new NotImplementedException();
        }

        public override void MoveForward(float speed, float turn)
        {
            Speed = speed;
            Turn += turn;

            ChildRotation = new Vector3(0, Turn, 0);

            //throw new NotImplementedException();
        }

        public override void ChildUpdate()
        {
            ChildTransform = me.transform.forward * Speed;
            me.transform.localPosition += ChildTransform;
            me.transform.localEulerAngles = ChildRotation;

            //throw new NotImplementedException();
        }

        public override void Speak()
        {
            Debug.Log(me.name + " word");

            //base.Speak();
        }
    }

    public class ChildB : ChildA
    {
        #region ChildB_properties
        private Color mColor;
        public Color MyColor
        {
            get { return mColor; }
            set { mColor = value; }
        }
        #endregion

        public override void Initialize(Mesh mesh, Material material)
        {
            base.Initialize(mesh, material);
            this.MyColor = new Color(1, 0, 0, 1);
            MyMeshRenderer.material.color = this.MyColor;

            // partial
            SetScale(2.0f);
            //base.Initialize(mesh, material);
        }
    }

    public Mesh ChildMesh;
    public Material ChildMaterial;

    BaseClass[] children;

    void Start()
    {
        children = new BaseClass[2];
        children[0] = new ChildA();
        children[0].Initialize(ChildMesh, ChildMaterial);
        children[1] = new ChildB();
        children[1].Initialize(ChildMesh, ChildMaterial);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    for(int i = 0; i < children.Length; i++)
        {
            children[i].MoveForward(i * 0.1f + 0.1f, i * 3.0f + 1.5f);
            children[i].ChildUpdate();
            children[i].Speak();
        }
	}

    public partial class ChildA : BaseClass
    {
        private float mScale;
        protected float MyScale
        {
            get { return mScale; }
            set { mScale = value; }
        }

        protected void SetScale(float scale)
        {
            MyScale = scale;
            me.transform.localScale = Vector3.one * MyScale;
        }
    }
}
