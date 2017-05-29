using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Common;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Text;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.Inputs;
using System;
using MonoDragons.Core.Navigation;
using MonoDragons.Core.Render;

namespace MonoDragons.Core.Engine
{
    public static class World
    {
        private static readonly ColoredRectangle _darken = new ColoredRectangle { Color = Color.FromNonPremultiplied(0, 0, 0, 130),
            Transform = new Transform2(new Size2(1920, 1080)) };
        private static readonly Events _events = new Events();
        private static readonly Events _persistentEvents = new Events();
        private static readonly List<EventSubscription> _eventSubs = new List<EventSubscription>();

        public static int CurrentEventSubscriptionCount => _events.SubscriptionCount + _persistentEvents.SubscriptionCount;

        private static Game _game;
        private static ContentManager _content;
        private static SpriteBatch _spriteBatch;
        private static INavigation _navigation;
        private static Display _display;

        public static void Init(Game game, INavigation navigation, SpriteBatch spriteBatch, Display display)
        {
            _game = game;
            _content = game.Content;
            _navigation = navigation;
            _spriteBatch = spriteBatch;
            _display = display;
            DefaultFont.Load(_content);
        }

        public static void Draw(Texture2D texture, Rectangle rectangle, Color color)
        {
            _spriteBatch.Draw(texture, ScaleRectangle(rectangle), color);
        }


        public static void NavigateToScene(string sceneName)
        {
            Input.ClearBindings();
            Resources.Unload();
            _navigation.NavigateTo(sceneName);
        }

        public static void DrawBackgroundColor(Color color)
        {
            _game.GraphicsDevice.Clear(color);
        }

        public static void Draw(string imageName, Vector2 pixelPosition)
        {
            var resource = Resources.Load<Texture2D>(imageName);
            _spriteBatch.Draw(resource, new Rectangle(ScalePoint(pixelPosition), ScalePoint(resource.Width, resource.Height)), Color.White);
        }

        public static void Draw(string imageName, Rectangle rectPostion)
        {
            _spriteBatch.Draw(Resources.Load<Texture2D>(imageName), ScaleRectangle(rectPostion), Color.White);
        }

        public static void Draw(Texture2D texture, Rectangle rectPosition)
        {
            Resources.Put(texture.GetHashCode().ToString(), texture);
            _spriteBatch.Draw(texture, ScaleRectangle(rectPosition), Color.White);
        }

        public static void DrawRotatedFromCenter(Texture2D texture, Rectangle rectPosition, Rotation2 rotation)
        {
            Resources.Put(texture.GetHashCode().ToString(), texture);
            var ScaledRect = ScaleRectangle(rectPosition);
            _spriteBatch.Draw(texture, null, ScaledRect, null, new Vector2(ScaledRect.Width / 2, ScaledRect.Height / 2),
                rotation.Value * .017453292519f, new Vector2(1, 1));
        }

        //[DebuggerStepThrough]
        public static void Publish(object payload)
        {
            //Debug.WriteLine(payload.GetType());
            _events.Publish(payload);
            _persistentEvents.Publish(payload);
        }

        public static void SubscribeForever(EventSubscription subscription)
        {
            _persistentEvents.Subscribe(subscription);
        }

        public static void Subscribe(EventSubscription subscription)
        {
            _events.Subscribe(subscription);
            _eventSubs.Add(subscription);
            Resources.Put(subscription.GetHashCode().ToString(), subscription);
        }

        public static void Unsubscribe(object owner)
        {
            _events.Unsubscribe(owner);
            _persistentEvents.Unsubscribe(owner);
            _eventSubs.Where(x => x.Owner.Equals(owner)).ForEach(x => 
                {
                    Resources.NotifyDisposed(x);
                    _eventSubs.Remove(x);
                });
        }

        public static void Draw(Texture2D texture, Vector2 position)
        {
            _spriteBatch.Draw(texture, new Rectangle(ScalePoint(position), ScalePoint(texture.Width, texture.Height)), Color.White);
        }

        public static void Draw(string name, Transform2 transform)
        {
             Draw(name, transform.ToRectangle());
        }

        public static void DrawRotatedFromCenter(string name, Transform2 transform)
        {
            var resource = Resources.Load<Texture2D>(name);
            var x = transform.Rotation.Value;
            _spriteBatch.Draw(resource, null, ScaleRectangle(transform.ToRectangle()), null, new Vector2(resource.Width / 2, resource.Height / 2),
                transform.Rotation.Value * .017453292519f, new Vector2(1, 1));
        }

        public static void Draw(Texture2D texture, Transform2 transform)
        {
            Draw(texture, transform.ToRectangle());
        }

        public static void Darken()
        {
            _darken.Draw(Transform2.Zero);
        }

        private static Rectangle ScaleRectangle(Rectangle rectangle)
        {
            return new Rectangle(ScalePoint(rectangle.Location), ScalePoint(rectangle.Size));
        }

        private static Point ScalePoint(float x, float y)
        {
            return ScalePoint(new Vector2(x, y));
        }

        private static Point ScalePoint(Vector2 vector)
        {
            return new Point((int)Math.Round(vector.X * _display.Scale), (int)Math.Round(vector.Y * _display.Scale));
        }

        private static Point ScalePoint(Point point)
        {
            return ScalePoint(point.ToVector2());
        }
    }
}
