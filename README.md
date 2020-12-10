
Instructions to reproduce:

- Two new scriptable objects were create, "Foo" and "Bar"
  - "Foo" implements serialization callback receiver
  - "Foo" can have a reference to a "Bar" object
  - "Foo.baz" is set to the value of "Bar.baz" in the serialization callback
- Open Assets/TestData/FooBar
- Change bar.baz to "62" (should originally be 42)
- Change foo.boz to "100" (should originally be 50)
- When you change foo.boz, you should see foo.Baz update to 62.
- Save Changes
- git diff should show changes on disk as you'd expect
```
$git diff                                                                                                     9:58:59
diff --git a/Assets/TestData/FooBar/bar.asset b/Assets/TestData/FooBar/bar.asset
index c8e4c19..31aafaa 100644
--- a/Assets/TestData/FooBar/bar.asset
+++ b/Assets/TestData/FooBar/bar.asset
@@ -12,4 +12,4 @@ MonoBehaviour:
   m_Script: {fileID: 11500000, guid: b16ded0efdcd54671a2bb85a75550f2c, type: 3}
   m_Name: bar
   m_EditorClassIdentifier: 
-  baz: 42
+  baz: 62
diff --git a/Assets/TestData/FooBar/foo.asset b/Assets/TestData/FooBar/foo.asset
index 9882ffc..695f194 100644
--- a/Assets/TestData/FooBar/foo.asset
+++ b/Assets/TestData/FooBar/foo.asset
@@ -13,5 +13,5 @@ MonoBehaviour:
   m_Name: foo
   m_EditorClassIdentifier: 
   bar: {fileID: 11400000, guid: 73d92364c6efe4a9e89b8f6c259d729d, type: 2}
-  baz: 42
-  boz: 50
+  baz: 62
+  boz: 100
```
- next, reset changes: `$git reset --hard`
- go back to unity, object "foo" should be selected
  - value of "Baz" is 62
  - if you check "bar", "Baz" is 42
- So the issue is that when the serialization callback happened on foo, it received the old version of bar (not the new version).
- Expected result: "foo.baz" would be 42 after the hard reset and return to unity