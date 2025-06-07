mergeInto(LibraryManager.library, {
  Speak: function (ptr) {
    const msg = UTF8ToString(ptr);
    speechSynthesis.speak(new SpeechSynthesisUtterance(msg));
  }
});