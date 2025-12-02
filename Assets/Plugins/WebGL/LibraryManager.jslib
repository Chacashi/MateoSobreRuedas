mergeInto(LibraryManager.library, {
  SetTime: function (text) {
    window.dispatchReactUnityEvent("SetTime", UTF8ToString(text));
  },
});