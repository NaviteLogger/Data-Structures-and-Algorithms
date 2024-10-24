import collections
from random import choice,shuffle

Card = collections.namedtuple('Card', ['rank','suit'])

class PolishDeck:
    ranks = [str(n) for n in range (2,11)] + list('WDKA')
    suits = 'spades diamonds clubs hearts'.split()
    def __init__(self):
        self._cards = [Card(rank,suit) for suit in self.suits for rank in self.ranks]
    def __len__(self):
        return len(self._cards)
    def __getitem__(self, position):
        return self._cards[position]
    
    exemplar_card = Card('7', 'diamonds')
    print(exemplar_card)
    
deck = PolishDeck()   
print(len(deck))
print(deck[0])
print(deck[-1])
print(deck[:3])
print(choice(deck))
print(choice(deck))
print(choice(deck))
print(deck[:3])
print(deck[12::13])
    