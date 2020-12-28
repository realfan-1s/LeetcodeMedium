using System.Collections.Generic;
// 字典+双链表
public class LRUCache {
    Dictionary<int, Node> dict;
    int cap;
    DoubleList cache;
    public LRUCache(int capacity) {
        dict = new Dictionary<int, Node>();
        cache = new DoubleList();
        cap = capacity;
    }
    public int Get(int key) {
        Node node = (dict.ContainsKey(key) ? dict[key] : null);
        if (node != null){
            cache.MoveNode(node);
            return node.value;
        }
        return -1;
    }
    public void Put(int key, int value) {
        Node node = (dict.ContainsKey(key) ? dict[key] : null);
        if (node == null){
            node = new Node(key, value);
            cache.AddToHead(node);
            dict.Add(key, node);
            if (dict.Count > cap){
                Node tmp = cache.RemoveTail();
                dict.Remove(tmp.key);
            }
        }else{
            node.value = value;
            dict[key] = node;
            cache.MoveNode(node);
        }
    }
    public class Node{
        public int key;
        public int value;
        public Node prev;
        public Node next;
        public Node(int key, int value){
            this.key = key;
            this.value = value;
        }
    }

    public class DoubleList{
        private Node head = new Node(0, 0);
        private Node tail = new Node(0, 0);
        public DoubleList(){
            head.next = tail;
            tail.prev = head;
        }
        public void AddToHead(Node node){
            node.next = head.next;
            head.next.prev = node;
            head.next = node;
            node.prev = head;
        }
        public void RemoveNode(Node node){
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }
        public void MoveNode(Node node){
            RemoveNode(node);
            AddToHead(node);
        }
        public Node RemoveTail(){
            Node tmp = tail.prev;
            RemoveNode(tmp);
            return tmp;
        }
    }
}