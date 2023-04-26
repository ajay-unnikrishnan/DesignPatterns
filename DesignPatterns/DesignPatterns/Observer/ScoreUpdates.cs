using System;
using System.Collections.Generic;

namespace DesignPatterns.Observer
{
    public class ScoreUpdates
    {
        public void Debug()
        {
            var subject = new MatchResult();
            var listerner1 = new NewsBroadcast();
            var listerner2 = new OnlineScoreUpdates();
            subject.Subscribe(listerner1);
            subject.Subscribe(listerner2);
            subject.Score = 10;
            subject.UnSubscribe(listerner1);
            subject.UnSubscribe(listerner2);
            subject.Score = 20;
        }
    }
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);
        void Notify();
    }
    public interface IObserver
    {
        void Update(int score);
    }
    public class MatchResult : IObservable
    {
        List<IObserver> observers;
        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                Notify();
            }
        }
        public MatchResult()
        {
            observers = new List<IObserver>();
        }
        public void Subscribe(IObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }
        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(_score);
            }
        }

        public void UnSubscribe(IObserver observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }
    }
    public class NewsBroadcast : IObserver
    {
        public void Update(int score)
        {
            Console.WriteLine("The score from NewsBroadcast: " + score);
        }
    }
    public class OnlineScoreUpdates : IObserver
    {
        public void Update(int score)
        {
            Console.WriteLine("The score from OnlineScoreUpdates: " + score);
        }
    }
}
