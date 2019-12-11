using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iso.Framework
{
    // TODO: flatten scenenode tree

    public class SceneNode : IUpdatable, IContent, IEnumerable<SceneNode>
    {
        private List<SceneNode> _nodes;

        public SceneNode()
        {
            _nodes = new List<SceneNode>();
            
            this.Enabled = true;
        }

        public void Load(ContentManager content)
        {
            if (!this.ContentLoaded)
            {
                this.OnLoad(content);
            }
            this.ContentLoaded = true;
        }

        protected virtual void OnLoad(ContentManager content)
        {
        }

        public void Update(GameTime time)
        {
            if (this.Enabled)
            {
                this.OnUpdate(time);
                
                foreach (var node in _nodes)
                {
                    node.Update(time);
                }
            }
        }

        protected virtual void OnUpdate(GameTime time)
        {
        }

        #region List

        public void Add(SceneNode node)
        {
            if (node.Parent != null)
            {
                throw new Exception("SceneNode already has a parent");
            }

            node.Parent = this;
            _nodes.Add(node);

            if (this.ContentLoaded && !node.ContentLoaded)
            {
                node.Load(Engine.Instance.Content);
            }

            this.OnNodeAdded(node);
        }

        public void Remove(SceneNode node)
        {
            node.Parent = null;
            _nodes.Remove(node);

            this.OnNodeRemoved(node);
        }

        public void Clear()
        {
            foreach (var node in _nodes)
            {
                node.Parent = null;
            }
            _nodes.Clear();
            this.OnCleared();
        }

        protected virtual void OnNodeAdded(SceneNode node)
        {
        }

        protected virtual void OnNodeRemoved(SceneNode node)
        {
        }

        protected virtual void OnCleared()
        {
        }

        public IEnumerator<SceneNode> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }

        #endregion

        public bool Enabled { get; set; }

        public bool ContentLoaded { get; set; }

        public SceneNode Parent { get; private set; }

        public SceneNode this[int index]
        {
            get
            {
                return _nodes[index];
            }
        }

        public int Count => _nodes.Count;
    }
}
